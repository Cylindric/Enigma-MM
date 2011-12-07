using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace Deploy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> paths = new Dictionary<string, string>();
            paths.Add("minecraft", "Minecraft");
            paths.Add("cache", "Cache");
            paths.Add("c10t", "C10t");
            paths.Add("overviewer", "Overviewer");
            paths.Add("backups", "Backups");
            paths.Add("maps", "Maps");

            // The base-path is the location of the current executable
            string buildRoot = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Substring(8));
            string projectRoot = Path.GetDirectoryName(buildRoot);
            string deployRoot = Path.Combine(projectRoot, "Deploy");
            string sourceRoot = Path.Combine(projectRoot, "Solution");

            // Clean and create the deployment root
            if (Directory.Exists(deployRoot))
            {
                Directory.Delete(deployRoot, true);
            }
            Directory.CreateDirectory(deployRoot);

            // Copy the main deployment files
            CopyFiles(buildRoot, deployRoot, "*.exe");
            CopyFiles(buildRoot, deployRoot, "*.dll");

            // Remove extra files
            DeleteFiles(deployRoot, "*.vshost.exe");
            DeleteFiles(deployRoot, "Bootstrap.exe");
            DeleteFiles(deployRoot, "MinecraftSimulator.exe");
            DeleteFiles(deployRoot, "Moq.dll");
            DeleteFiles(deployRoot, "nunit.framework.dll");
            DeleteFiles(deployRoot, "Test.NullCommand.exe");
            DeleteFiles(deployRoot, "Tests.dll");
        }


        private static void CopyFiles(string buildRoot, string deployRoot, string filter)
        {
            List<String> files = Directory.GetFiles(buildRoot, filter).ToList();
            foreach (string file in files)
            {
                FileInfo mFile = new FileInfo(file);
                mFile.CopyTo(Path.Combine(deployRoot, mFile.Name));
            }
        }

        private static void DeleteFiles(string deployRoot, string filter)
        {
            List<String> files = Directory.GetFiles(deployRoot, filter).ToList();
            foreach (string file in files)
            {
                FileInfo mFile = new FileInfo(file);
                mFile.Delete();
            }
        }
    
    }
}
