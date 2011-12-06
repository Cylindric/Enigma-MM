using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.IO.Compression;

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
