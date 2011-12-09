using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Xml;
using EnigmaMM.Engine;
using EnigmaMM.Engine.Data;

namespace EnigmaMM.Scheduler
{
    /// <summary>
    /// Provides functionality for managing scheduled tasks that can execute at
    /// pre-defined repeating intervals.
    /// </summary>
    public class SchedulerManager
    {
        private const int TIMER_INTERVAL = 5000;
        private EMMServer mServer;
        private List<ScheduleTask> mTasks;
        private Timer mTimer;

        /// <summary>
        /// Gets or sets the <seealso cref="EMMServer"/> to use for executing the
        /// scheduled commands.
        /// </summary>
        public EMMServer Server
        {
            get { return mServer; }
            set { mServer = value; }
        }

        /// <summary>
        /// Gets the <seealso cref="IScheduleTask"/> that is scheduled to run next.
        /// </summary>
        /// <remarks>If no tasks are scheduled, returns <c>null</c>.</remarks>
        public ScheduleTask NextTask
        {
            get
            {
                ScheduleTask next = null;
                foreach (ScheduleTask task in mTasks)
                {
                    if ((next == null) || (task.NextRun < next.NextRun))
                    {
                        next = task;
                    }
                }
                return next;
            }
        }

        /// <summary>
        /// Creates a new ScheduleManager with default values, linked to the 
        /// specified <see cref="EMMServer"/>.
        /// </summary>
        /// <param name="server">The EMMServer to use for executing commands.</param>
        public SchedulerManager(EMMServer server)
        {
            mServer = server;
            mTasks = new List<ScheduleTask>();
            mTimer = new Timer();
            mTimer.Elapsed += onTimerEvent;
        }

        /// <summary>
        /// Starts the scheduler.
        /// </summary>
        public void Start()
        {
            this.LoadSchedule();
            mTimer.Interval = TIMER_INTERVAL;
            processTimer(DateTime.Now);
            mTimer.Start();
        }

        /// <summary>
        /// Stops the scheduler.
        /// </summary>
        public void Stop()
        {
            mTimer.Stop();
        }

        /// <summary>
        /// Loads the schedule from the database
        /// </summary>
        private void LoadSchedule()
        {
            foreach (Schedule s in Manager.GetContext.Schedules)
            {
                ScheduleTask task = new ScheduleTask();
                task.OriginalDbId = s.Schedule_ID;
                task.Name = s.Name;
                task.Command = s.Command;

                task.RunDays = "*";
                task.RunHours = "*";
                task.RunMinutes = "*";

                if (s.ScheduleType.Code == "startup")
                {
                    task.RunDays = "@startup";
                }
                else
                {
                    if (s.Days >= 0)
                    {
                        task.RunDays = s.Days.ToString();
                    }

                    if (s.Hours >= 0)
                    {
                        task.RunHours = s.Hours.ToString();
                    }

                    if (s.Minutes >= 0)
                    {
                        task.RunMinutes = s.Minutes.ToString();
                    }
                }
                AddTask(task);
            }
        }

        /// <summary>
        /// Adds the specified <see cref="ScheduleTask"/> to the task list.
        /// </summary>
        /// <param name="task">The task to add.</param>
        public void AddTask(ScheduleTask task)
        {
            task.CalculateNextRunTime();
            mTasks.Add(task);
        }


        private void processTimer(DateTime signalTime)
        {
            if (mTasks.Count == 0)
            {
                return;
            }

            // Run all "missed" tasks and increment their run-times
            foreach (ScheduleTask task in mTasks)
            {
                if (task.NextRun <= signalTime)
                {
                    ExecuteTask(task);
                }

                // Determine if the next-run time is sooner than the next scheduled run-time, and if it is shorten the delay.
                DateTime nextTimerEvent = signalTime.AddMilliseconds(mTimer.Interval);
                if (NextTask.NextRun < nextTimerEvent)
                {
                    mTimer.Interval = (nextTimerEvent - NextTask.NextRun).TotalMilliseconds;
                }
                else
                {
                    mTimer.Interval = TIMER_INTERVAL;
                }
            }
        }


        private void onTimerEvent(object source, ElapsedEventArgs e)
        {
            processTimer(e.SignalTime);
        }

        private void ExecuteTask(ScheduleTask task)
        {
            task.CalculateNextRunTime();
            if (mServer != null)
            {
                mServer.RaiseServerMessage(string.Format("Running scheduled task '{0}'.  Next run will be {1}.", task.Name, task.NextRun));
                mServer.Execute(task.Command);
            }
        }

    }
}

