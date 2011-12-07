using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Ionic.Zip;

namespace Bootstrap
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
            string emmRoot = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Substring(8));

            // Update all the paths with the absolute paths
            foreach (string key in new List<string>(paths.Keys))
            {
                paths[key] = Path.Combine(emmRoot, paths[key]);
            }

            // Create the paths
            foreach (KeyValuePair<string, string> p in paths)
            {
                if (!Directory.Exists(p.Value))
                {
                    Directory.CreateDirectory(p.Value);
                }
            }

            // Get any external tools that we can
            DownloadFile(
                Path.Combine(paths["minecraft"], "minecraft_server.jar"),
                "https://s3.amazonaws.com/MinecraftDownload/launcher/minecraft_server.jar",
                "Minecraft"
            );

            DownloadFile(
                Path.Combine(paths["overviewer"], "overviewer.exe"),
                "https://github.com/downloads/overviewer/Minecraft-Overviewer/win86_32-v0.3.0-215-g8390ec4.zip",
                "Overviewer"
            );

            DownloadFile(
                Path.Combine(paths["c10t"], "c10t.exe"),
                "http://toolchain.eu/minecraft/c10t/releases/c10t-1.9-windows-x86.zip",
                "C10t"
            );

            // C10t extracts into a subfolder, so move the files up one level
            PromoteDirectory(Path.Combine(paths["c10t"], "c10t-1.9-windows-x86"));
        }

        private static void PromoteDirectory(string extractRoot)
        {
            foreach (string filename in Directory.GetFiles(extractRoot))
            {
                File.Move(filename, Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(filename)), Path.GetFileName(filename)));
            }
            foreach (string dir in Directory.GetDirectories(extractRoot))
            {
                Directory.Move(dir, Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(dir)), Path.GetFileName(dir)));
            }
            Directory.Delete(extractRoot);
        }

        private static void DownloadFile(string filename, string url, string name)
        {
            if (!File.Exists(filename))
            {
                try
                {
                    string downloadpath = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileName(url));
                    Console.Write("Attempting to download {0}...", name);
                    if (File.Exists(downloadpath))
                    {
                        Console.WriteLine("download file already exists!");
                    }
                    else
                    {
                        WebClient web = new WebClient();
                        web.DownloadFile(url, downloadpath);
                        Console.WriteLine("done");
                    }
                    if (Path.GetExtension(downloadpath) == ".zip")
                    {
                        using (ZipFile zip = new ZipFile(downloadpath))
                        {
                            zip.ExtractAll(Path.GetDirectoryName(downloadpath), ExtractExistingFileAction.OverwriteSilently);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("could not download!");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void Unzip(string filename)
        {
        }
    }
}
