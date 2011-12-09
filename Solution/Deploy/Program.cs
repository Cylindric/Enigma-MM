using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Ionic.Zip;

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
            paths.Add("biomeextractor", "BiomeExtractor");

            // The base-path is the location of the current executable
            string buildRoot = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Substring(8));
            string projectRoot = Path.GetDirectoryName(buildRoot);
            string deployRoot = Path.Combine(projectRoot, "Deploy");
            string sourceRoot = Path.Combine(projectRoot, "Solution");
            string stagingRoot = Path.Combine(deployRoot, "staging");

            // Clean and create the deployment root
            if (Directory.Exists(deployRoot))
            {
                Directory.Delete(deployRoot, true);
            }
            Directory.CreateDirectory(deployRoot);
            Directory.CreateDirectory(stagingRoot);

            // Create the empty directories
            foreach (KeyValuePair<string, string> p in paths)
            {
                if (!Directory.Exists(p.Value))
                {
                    Directory.CreateDirectory(Path.Combine(stagingRoot, p.Value));
                }
            }

            // Copy the main deployment files
            CopyFiles(buildRoot, stagingRoot, "Server.exe");
            CopyFiles(buildRoot, stagingRoot, "LibNbt.dll");
            CopyFiles(buildRoot, stagingRoot, "Ionic.Zip.Reduced.dll");

            // Build the monolithic license readme
            string readme = File.ReadAllText(Path.Combine(projectRoot, "readme.txt"));
            string nbtLic = File.ReadAllText(Path.Combine(sourceRoot, "LibNbt", "libnbt.txt"));
            string ionLic = File.ReadAllText(Path.Combine(sourceRoot, "Server", "Engine", "Ionic.txt"));

            StringBuilder finalReadme = new StringBuilder();
            finalReadme.AppendLine("##### Contents");
            finalReadme.AppendLine("##1## Readme");
            finalReadme.AppendLine("##2## LibNbt License");
            finalReadme.AppendLine("##3## Ionic Zip License");
            finalReadme.AppendLine("#####");
            finalReadme.AppendLine("");
            finalReadme.AppendLine("");
            finalReadme.AppendLine("################################################################################");
            finalReadme.AppendLine("##1## Readme");
            finalReadme.AppendLine("################################################################################");
            finalReadme.AppendLine(File.ReadAllText(Path.Combine(projectRoot, "readme.txt")));
            finalReadme.AppendLine("");
            finalReadme.AppendLine("");
            finalReadme.AppendLine("################################################################################");
            finalReadme.AppendLine("##2## LibNbt License");
            finalReadme.AppendLine("################################################################################");
            finalReadme.AppendLine(File.ReadAllText(Path.Combine(sourceRoot, "LibNbt", "libnbt.txt")));
            finalReadme.AppendLine("");
            finalReadme.AppendLine("");
            finalReadme.AppendLine("################################################################################");
            finalReadme.AppendLine("##3## Ionic Zip License");
            finalReadme.AppendLine("################################################################################");
            finalReadme.AppendLine(File.ReadAllText(Path.Combine(sourceRoot, "Server", "Engine", "Ionic.txt")));

            using (StreamWriter file = new System.IO.StreamWriter(Path.Combine(stagingRoot, "readme.txt")))
            {
                file.WriteLine(finalReadme.ToString());
            }

            // zip everything up
            using (ZipFile zip = new ZipFile())
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                zip.AddSelectedFiles("*", stagingRoot, "", true);
                zip.Save(Path.Combine(deployRoot, "Enigma-MM.zip"));
            }

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
