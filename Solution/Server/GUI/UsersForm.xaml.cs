using System.Linq;
using System.Windows;
using System.Windows.Data;
using EnigmaMM.Engine;
using EnigmaMM.Engine.Data;
using EnigmaMM.Engine.Gui;

    namespace EnigmaMM
    {
        public partial class UsersForm : Window
        { 
            private ObservableUsers users;

            public UsersForm()
            {
                InitializeComponent();
            }

            #region Form Event Handlers
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                this.LoadFormData();
            }

            private void OkButton_Click(object sender, RoutedEventArgs e)
            {
                this.SaveFormData();
                this.CloseForm();
            }

            private void usersDataGrid_RowEditEnding(object sender, System.Windows.Controls.DataGridRowEditEndingEventArgs e)
            {
                ApplyButton.IsEnabled = true;
            }

            private void CancelButton_Click(object sender, RoutedEventArgs e)
            {
                this.CloseForm();
            }

            private void ApplyButton_Click(object sender, RoutedEventArgs e)
            {
                this.SaveFormData();
            }
            #endregion

            private void LoadFormData()
            {
                users = new ObservableUsers();
                usersDataGrid.ItemsSource = users;

                CollectionViewSource ranks = (CollectionViewSource)FindResource("RankLookup");
                ranks.Source = from rank in Manager.GetContext.Ranks
                               orderby rank.Level
                               select rank;
            }

            private void SaveFormData()
            {
                this.users.Save();
            }

            private void CloseForm()
            {
                this.Close();
            }

        }
    }
