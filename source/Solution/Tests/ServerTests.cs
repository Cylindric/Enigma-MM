﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using System.Threading;
using EnigmaMM.Interfaces;

namespace EnigmaMM
{
    [TestFixture]
    [Category("Server")]
    public class ServerTests
    {
        private EMMServer mPersistentServer;
        private const int SLEEP_STEP = 100;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            // Reflection within the server will yield the incorrect directory for settings, so we need to set it here.
            string testRoot = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Substring(8));
            string settingsFile = Path.Combine(testRoot, "settings.conf");

            using (TextWriter tw = new StreamWriter(settingsFile))
            {
                tw.WriteLine(string.Format("MinecraftRoot={0}", testRoot));
                tw.WriteLine(@"ServerJar=.\MinecraftSimulator.exe");
                tw.Close();
            }
            Console.WriteLine("Settings File is: " + settingsFile);

            mPersistentServer = new EMMServer(settingsFile);
            Assert.That(Settings.Filename, Is.EqualTo(settingsFile));

            mPersistentServer.StartServer();
            WaitForServerStatus(EMMServer.Status.Running, 3000);
        }

        [TestFixtureTearDown]
        public void FixtureTeardown()
        {
            mPersistentServer.StopServer(false, 0, true);
            mPersistentServer = null;
        }

        [Test]
        public void TestServerRecognisesNewUser()
        {
            Assert.That(mPersistentServer.CurrentStatus, Is.EqualTo(EMMServer.Status.Running));
            int startingUsers = mPersistentServer.Users.Count;

            AddUser(1);
            Assert.That(mPersistentServer.Users.Count, Is.EqualTo(startingUsers + 1));

            AddUser(1);
            Assert.That(mPersistentServer.Users.Count, Is.EqualTo(startingUsers + 2));

            // cleanup
            RemoveUser(2);
            Assert.That(mPersistentServer.Users.Count, Is.EqualTo(startingUsers));
        }

        [Test]
        public void TestServerRecognisesRemoveUser()
        {
            Assert.That(mPersistentServer.CurrentStatus, Is.EqualTo(EMMServer.Status.Running));
            int startingUsers = mPersistentServer.Users.Count;

            AddUser(2);
            Assert.That(mPersistentServer.Users.Count, Is.EqualTo(startingUsers + 2));

            RemoveUser(1);
            Assert.That(mPersistentServer.Users.Count, Is.EqualTo(startingUsers + 1));

            RemoveUser(1);
            Assert.That(mPersistentServer.Users.Count, Is.EqualTo(startingUsers));
        }

        [Test]
        public void TestServerStopsGracefully()
        {
            int startingUsers = mPersistentServer.Users.Count;
            Assert.That(mPersistentServer.CurrentStatus, Is.EqualTo(EMMServer.Status.Running));

            // ensure at least 1 user is online
            AddUser(1);

            mPersistentServer.StopServer(true);
            WaitForServerStatus(EMMServer.Status.PendingStop);

            // remove all users
            RemoveUser(mPersistentServer.Users.Count);

            WaitForServerStatus(EMMServer.Status.Stopped);

            // cleanup
            mPersistentServer.StartServer();
            WaitForServerStatus(EMMServer.Status.Running);
        }

        [Test]
        public void TestServerRestartsGracefully()
        {
            int startingUsers = mPersistentServer.Users.Count;
            Assert.That(mPersistentServer.CurrentStatus, Is.EqualTo(EMMServer.Status.Running));

            // ensure at least 1 user is online
            AddUser(1);

            mPersistentServer.RestartServer(true);
            WaitForServerStatus(EMMServer.Status.PendingRestart);

            // remove all users
            RemoveUser(mPersistentServer.Users.Count);

            WaitForServerStatus(EMMServer.Status.Running);
        }

        /// <summary>
        /// Adds the specified number of users to the simulator.
        /// Throws an Assert if count doesn't increment by expected number.
        /// </summary>
        /// <param name="n">Number of users to add.</param>
        private void AddUser(int n)
        {
            Console.Write(string.Format("Adding {0} user(s)...", n));
            for (int i = 0; i < n; i++)
            {
                int startingUsers = mPersistentServer.Users.Count;
                mPersistentServer.SendCommand("!useradd");
                WaitForUserCount(startingUsers + 1);
            }
            Console.WriteLine(string.Format("done ({0} online)", mPersistentServer.Users.Count));
        }

        /// <summary>
        /// Removes the specified number of users from the simulator.
        /// Throws an Assert if count doesn't decrement by expected number.
        /// </summary>
        /// <param name="n">Number of users to remove.</param>
        private void RemoveUser(int n)
        {
            Console.Write(string.Format("Removing {0} user(s)...", n));
            for (int i = 0; i < n; i++)
            {
                int startingUsers = mPersistentServer.Users.Count;
                mPersistentServer.SendCommand("!userdel");
                WaitForUserCount(startingUsers - 1);
            }
            Console.WriteLine(string.Format("done ({0} online)", mPersistentServer.Users.Count));
        }

        /// <summary>
        /// Blocks until the number of online users matches the specified targetCount.
        /// </summary>
        /// <remarks>Throws an Assert if count doesn't reach by expected number.</remarks>
        /// <param name="targetCount">Number of users to wait for.</param>
        private void WaitForUserCount(int targetCount)
        {
            int maxWait = 1000;
            while ((mPersistentServer.Users.Count != targetCount) && (maxWait > 0))
            {
                Thread.Sleep(SLEEP_STEP);
                Console.Write(".");
                maxWait -= SLEEP_STEP;
            }
            Assert.That(mPersistentServer.Users.Count, Is.EqualTo(targetCount));
        }

        /// <summary>
        /// Blocks until the server status matches the specified value.
        /// </summary>
        /// <remarks>Throws an Assert if status isn't reached</remarks>
        /// <param name="targetStatus">The status to reach.</param>
        private void WaitForServerStatus(EMMServer.Status targetStatus) { WaitForServerStatus(targetStatus, 1000); }

        /// <summary>
        /// Blocks until the server status matches the specified value, within the specified time.
        /// </summary>
        /// <remarks>Throws an Assert if status isn't reached in the specified time.</remarks>
        /// <param name="targetStatus">The status to reach.</param>
        /// <param name="maxWait">Milliseconds to wait for status.</param>
        private void WaitForServerStatus(EMMServer.Status targetStatus, int maxWait)
        {
            Console.Write(string.Format("Waiting for status '{0}'...", targetStatus.ToString()));
            while ((mPersistentServer.CurrentStatus != targetStatus) && (maxWait > 0))
            {
                Thread.Sleep(SLEEP_STEP);
                Console.Write(".");
                maxWait -= SLEEP_STEP;
            }
            Console.WriteLine("done");
            Assert.That(mPersistentServer.CurrentStatus, Is.EqualTo(targetStatus));
        }
    
    }
}
