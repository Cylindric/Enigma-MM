﻿using System;
using EnigmaMM.Interfaces;

namespace EnigmaMM
{
    /// <summary>
    /// The CommandParser is a simple tool for converting user input into Server Manager or
    /// Minecraft commands.
    /// </summary>
    /// <remarks>Any unrecognised commands are passed up to Minecraft to process directly.</remarks>
    public class CommandParser
    {
        private IServer mMinecraft;
        /// <summary>
        /// Creates a new <c>CommandParser</c> and connects it to the specified <see cref="IServer"/>.
        /// </summary>
        /// <param name="minecraft"></param>
        public CommandParser(IServer minecraft)
        {
            mMinecraft = minecraft;
        }


        /// <summary>
        /// Handle a command from the CLI.
        /// Commands for the server manager are prefixed with the command-character.
        /// </summary>
        /// <param name="Command">The command to parse.</param>
        public bool ParseCommand(String Command)
        {
            bool executed = true;
            string[] args = Command.Split(' ');
            switch (args[0])
            {
                case ("quit"):
                    ParseCommand("stop");
                    break;

                case ("start"):
                    mMinecraft.StartServer();
                    break;

                case ("restart"):
                    ParseCommand("stop");
                    mMinecraft.StartServer();
                    break;

                case ("restart-graceful"):
                    mMinecraft.RestartServer(true);
                    break;

                case ("stop"):
                    mMinecraft.StopServer(false);
                    break;

                case ("stop-graceful"):
                    mMinecraft.StopServer(true);
                    break;

                case ("abort-graceful"):
                    mMinecraft.AbortPendingOperations();
                    break;

                case ("maps"):
                    mMinecraft.GenerateMaps(args);
                    break;

                case ("backup"):
                    mMinecraft.Backup();
                    break;

                default:
                    executed = false;
                    break;
            }
            return executed;
        }
    }
}
