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
            paths.Add("biomeextractor", "BiomeExtractor");

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
            Console.Write("Attempting to download the Minecraft server...");
            try
            {
                DownloadFile(
                    Path.Combine(paths["minecraft"], "minecraft_server.jar"),
                    "https://s3.amazonaws.com/MinecraftDownload/launcher/minecraft_server.jar",
                    "Minecraft"
                );

                Console.WriteLine("done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR!");
                Console.WriteLine("Failed to find and/or download");
                Console.WriteLine(ex.Message);
            }


            Console.Write("Attempting to download Overviewer...");
            try
            {
                if (File.Exists(Path.Combine(paths["overviewer"], "overviewer.exe")))
                {
                    Console.Write("already present...");
                }
                else
                {
                    Console.Write("searching...");
                    string overviewerUrl = GetLatestGitHubDownload("overviewer", "Minecraft-Overviewer");

                    DownloadFile(
                        Path.Combine(paths["overviewer"], "overviewer.exe"),
                        overviewerUrl,
                        "Overviewer"
                    );
                }
                Console.WriteLine("done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR!");
                Console.WriteLine("Failed to find and/or download");
                Console.WriteLine(ex.Message);
            }


            Console.Write("Attempting to download Biome Extractor...");
            try
            {
                if (File.Exists(Path.Combine(paths["biomeextractor"], "biomeextractor.jar")))
                {
                    Console.Write("already present...");
                }
                else
                {
                    Console.Write("searching...");
                    string overviewerUrl = GetLatestGitHubDownload("overviewer", "minecraft-biome-extractor");

                    DownloadFile(
                        Path.Combine(paths["biomeextractor"], "BiomeExtractor.jar"),
                        overviewerUrl,
                        "Biome Extractor"
                    );
                }
                Console.WriteLine("done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR!");
                Console.WriteLine("Failed to find and/or download");
                Console.WriteLine(ex.Message);
            }


            Console.Write("Attempting to download C10t...");
            try
            {
                if (File.Exists(Path.Combine(paths["c10t"], "c10t.exe")))
                {
                    Console.Write("already present...");
                }
                else
                {
                    DownloadFile(
                         Path.Combine(paths["c10t"], "c10t.exe"),
                         "http://toolchain.eu/minecraft/c10t/releases/c10t-1.9-windows-x86.zip",
                         "C10t"
                     );

                    // C10t extracts into a subfolder, so move the files up one level
                    Console.Write("promoting...");
                    PromoteDirectory(Path.Combine(paths["c10t"], "c10t-1.9-windows-x86"));
                }
                Console.WriteLine("done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR!");
                Console.WriteLine("Failed to find and/or download");
                Console.WriteLine(ex.Message);
            }
        }


        private static void PromoteDirectory(string extractRoot)
        {
            if (Directory.Exists(extractRoot))
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
            else
            {
                Console.WriteLine("ERROR!");
                Console.Write("Cannot promote directory {0}: not found", extractRoot);
            }
        }


        private static void DownloadFile(string filename, string url, string name)
        {
            if (File.Exists(filename))
            {
                Console.Write("already present...");
            }
            else
            {
                string downloadpath = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileName(url));
                if (File.Exists(downloadpath))
                {
                    Console.WriteLine("found...");
                }
                else
                {
                    Console.Write("downloading...");
                    WebClient web = new WebClient();
                    web.DownloadFile(url, downloadpath);
                }
                if (Path.GetExtension(downloadpath) == ".zip")
                {
                    Console.Write("extracting...");
                    using (ZipFile zip = new ZipFile(downloadpath))
                    {
                        zip.ExtractAll(Path.GetDirectoryName(downloadpath), ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                else
                {
                    if (filename != downloadpath)
                    {
                        File.Move(downloadpath, filename);
                    }
                }
            }
        }


        private static string GetLatestGitHubDownload(string owner, string repo)
        {
            string apiurl = string.Format("https://api.github.com/repos/{0}/{1}/downloads", owner, repo);
            WebRequest rw = WebRequest.Create(apiurl);
            WebResponse resp = rw.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string r = sr.ReadToEnd();

            // Poor-man's JSON decode :)
            // We only really need the first HTML_URL value
            int urlStart = r.IndexOf("html_url\":\"") + 11;
            int urlEnd = r.IndexOf("\"", urlStart + 1);
            string url = r.Substring(urlStart, urlEnd - urlStart);
            return url;
        }
    }
}
