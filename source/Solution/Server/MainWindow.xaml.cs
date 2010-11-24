﻿using System;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace EnigmaMM
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MCServer mMinecraft;
        private CommandParser mParser;
        private const int MAX_LOG_ENTRIES = 100;

        private InvokeOC<LogListItem> mLogItems;
        private object mLogItemLock;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Initialise()
        {
            // Setup the log viewer
            mLogItemLock = new object();
            mLogItems = new InvokeOC<LogListItem>(uxLogListView.Dispatcher);
            uxLogListView.ItemsSource = mLogItems;

            // Setup the server manager
            mMinecraft = new MCServer();
            mMinecraft.ServerMessage += HandleServerMessage;
            mMinecraft.StatusChanged += HandleServerMessage;
            mMinecraft.StartCommsServer();
            mParser = new CommandParser(mMinecraft);
            uxUserListView.ItemsSource = mMinecraft.Users;
        }

        private delegate void UpdateServerMetricsDelegate();
        private void UpdateServerMetrics()
        {
            if (this.Dispatcher.CheckAccess())
            {
                uxStartButton.IsEnabled = false;
                uxStopButton.IsEnabled = false;
                uxRestartButton.IsEnabled = false;
                uxStatusBarStatus.Text = mMinecraft.CurrentStatus.ToString();

                switch (mMinecraft.CurrentStatus)
                {
                    case MCServer.Status.Starting:
                        uxStatusBarStatusIcon.Source = new BitmapImage(new Uri("/Resources/status-starting.png", UriKind.Relative));
                        break;

                    case MCServer.Status.Stopping:
                        uxStatusBarStatusIcon.Source = new BitmapImage(new Uri("/Resources/status-stopping.png", UriKind.Relative));
                        break;

                    case MCServer.Status.Running:
                        uxStatusBarStatusIcon.Source = new BitmapImage(new Uri("/Resources/status-running.png", UriKind.Relative));
                        uxStopButton.IsEnabled = true;
                        uxRestartButton.IsEnabled = true;
                        break;

                    case MCServer.Status.PendingRestart:
                        uxStatusBarStatusIcon.Source = new BitmapImage(new Uri("/Resources/status-pendingrestart.png", UriKind.Relative));
                        uxStopButton.IsEnabled = true;
                        break;

                    case MCServer.Status.PendingStop:
                        uxStatusBarStatusIcon.Source = new BitmapImage(new Uri("/Resources/status-pendingstop.png", UriKind.Relative));
                        uxStopButton.IsEnabled = true;
                        uxRestartButton.IsEnabled = true;
                        break;

                    case MCServer.Status.Stopped:
                        uxStatusBarStatusIcon.Source = new BitmapImage(new Uri("/Resources/status-stopped.png", UriKind.Relative));
                        uxStartButton.IsEnabled = true;
                        break;

                    case MCServer.Status.Failed:
                        uxStatusBarStatusIcon.Source = new BitmapImage(new Uri("/Resources/status-failed.png", UriKind.Relative));
                        uxStartButton.IsEnabled = true;
                        break;
                }

                uxStatusBarUsers.Text = string.Format("Online users: {0}", mMinecraft.Users.Count);
            }
            else
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new UpdateServerMetricsDelegate(UpdateServerMetrics));
            }
        }

        private void SendServerCommand(string command)
        {
            AddMessageToLog(command);
            mParser.ParseCommand(command);
        }

        private void AddMessageToLog(string message)
        {
            //lock (mLogItemLock)
            //{
                mLogItems.Add(new LogListItem(message));
                if (mLogItems.Count > MAX_LOG_ENTRIES)
                {
                    mLogItems.RemoveAt(0);
                }
            //}
        }

        private delegate void HandleServerMessageDelegate(string message);
        private void HandleServerMessage(string message)
        {
            if (message.Length > 0)
            {
                AddMessageToLog(message);
            }
            UpdateServerMetrics();
        }

        private void uxStartButton_Click(object sender, RoutedEventArgs e)
        {
            mMinecraft.StartServer();
        }

        private void uxStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (uxGracefulCheckbox.IsChecked.Value)
            {
                mMinecraft.GracefulStop();
            }
            else
            {
                mMinecraft.StopServer();
            }
        }

        private void uxRestartButton_Click(object sender, RoutedEventArgs e)
        {
            if (uxGracefulCheckbox.IsChecked.Value)
            {
                mMinecraft.GracefulRestart();
            }
            else
            {
                mMinecraft.RestartServer();
            }
        }

        private void uxCommandInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendServerCommand(uxCommandInput.Text);
                uxCommandInput.Text = "";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Initialise();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mMinecraft.StopServer(60000, true);
        }

        private void uxLogListView_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            uxLogListView.SelectedIndex = uxLogListView.Items.Count - 1;
        }

    }

}
