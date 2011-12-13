using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnigmaMM.Engine.Data
{
    class UpdateDb_4_5 : UpdateDb
    {
        public override void DoUpdate()
        {
            mCommandQueue.Clear();

            mCommandQueue.Add(@"
            CREATE TABLE Schedules
            (
                [Schedule_ID] int IDENTITY PRIMARY KEY NOT NULL,
                [Schedule_Type_ID] int NOT NULL,
                [Enabled] bool NOT NULL DEFAULT true,
                [Name] nvarchar(50) NOT NULL,
                [Days] int NOT NULL DEFAULT 0,
                [Hours] int NOT NULL DEFAULT 0,
                [Minutes] int NOT NULL DEFAULT 0,
                [Command] nvarchar(50) NOT NULL DEFAULT '',
                [NextRunTime] DateTime,
                [LastRunTime] DateTime
            )
            ");

            ExecuteCommands();
            mDb.Configs.First(c => c.Key == "db_version").Value = "5";
        }
    }
}
