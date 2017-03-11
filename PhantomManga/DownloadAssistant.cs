using CloudFlareUtilities;
using Microsoft.Build.Execution;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhantomManga
{
    public static class DownloadAssistant
    {
        // Variables
        public static HttpClient client;
        private static List<MangaDownloadEntry> entrylist = new List<MangaDownloadEntry>();
        private static bool firstrun = true;
        private static ClearanceHandler handler = new ClearanceHandler();
        private static List<string> log = new List<string>();
        public static DownloadState state = DownloadState.Free;

        // Threads
        public static void Downloader()
        {
            client = new HttpClient(handler);
            handler.MaxRetries = 2;
            bool justkilled = false;

            while (true)
            {
                if (entrylist.Count > 0)
                {
                    if (state == DownloadState.Free)
                    {
                        Console.Title = "PhantomManga - Download Assistant (downloading)";
                        firstrun = false;
                        MangaDownloadEntry entry = entrylist[0];
                        Download(entry);
                        entrylist.RemoveAt(0);
                    }
                    else if (state == DownloadState.Killed)
                    {
                        justkilled = true;
                        entrylist.Clear();
                    }
                    else if (state == DownloadState.Restricted)
                        Console.Title = "PhantomManga - Download Assistant (paused)";
                }
                else
                    break;
            }

            Console.Clear();
            Console.Title = "PhantomManga - Download Assistant";
            if (firstrun)
            {
                Print("This console is the designated download assistant to PhantomManga.\nClosing this terminal will result in the termination of PhantomManga as a whole and will disrupt any active downloads.");
            }
            else
            {
                Print("All downloads finished.\n\nEntries highlighted ");
                Print("green ", ConsoleColor.Green);
                Print(" were succesfully downloaded, ");
                Print("red ", ConsoleColor.Red);
                Print("failed to download.\n\n");
            }
            foreach (string line in log)
                Print(line.Remove(0, 7) + "\n", line.StartsWith("SUCCESS") ? ConsoleColor.Green : (line.StartsWith("FAILURE") ? ConsoleColor.Red : ConsoleColor.Magenta));
            if (justkilled)
            {
                justkilled = false;
                Print("\nAll other downloads never started due to user interruption.");
            }

            while (entrylist.Count == 0)
                Application.DoEvents();
            Downloader();
        }

        // Methods
        public static void Add(MangaDownloadEntry entry)
        {
            state = DownloadState.Free;
            entrylist.Add(entry);
        }
        private static void Download(MangaDownloadEntry entry)
        {
            int chapter_num = entry.chapter_num;
            int chapter_ad = entry.chapter_ad;
            bool chapter_hasdec = entry.chapter_hasdec;
            bool chapter_hashyp = entry.chapter_hashyp;
            string manga_name = entry.manga_name;
            string manga_mfcode = entry.manga_rccode;
            int page_start = entry.page_start;
            int page_end = entry.page_end;
            bool resize = entry.resize;

            string chapter_dir = chapter_num.ToString("D3") + (chapter_hasdec ? ("." + chapter_ad) : (chapter_hashyp ? ("-" + chapter_ad) : ""));
            if (!Directory.Exists("data\\" + manga_mfcode + "\\manga"))
                Directory.CreateDirectory("data\\" + manga_mfcode + "\\manga");
            if (!Directory.Exists("data\\" + manga_mfcode + "\\manga\\" + chapter_dir))
                Directory.CreateDirectory("data\\" + manga_mfcode + "\\manga\\" + chapter_dir);

            for (int i = page_start; i <= page_end; i++)
            {
                Console.Clear();
                Print("Downloading " + manga_name + "\n- Chapter: " + chapter_dir + "\n- Page: " + i + " of " + page_end);
                try
                {
                    string saveloc = "data\\" + manga_mfcode + "\\manga\\" + chapter_dir + "\\" + i.ToString("D3") + ".jpg";
                    if (!File.Exists(saveloc))
                    {
                        string chapterstr = chapter_dir.TrimStart(new char[] { '0' });
                        string pagestr = "http://images.mangafreak.net/mangas/" + manga_mfcode + "/" + manga_mfcode + "_" + chapterstr + "/" + manga_mfcode + "_" + chapterstr + "_" + i + ".jpg";
                        
                        byte[] buffer = Task.Run<byte[]>(() => client.GetByteArrayAsync(pagestr)).Result;

                        if (resize)
                            buffer = ScaleImage(buffer, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                        File.WriteAllBytes(saveloc, buffer);
                    }
                }
                catch
                {
                    log.Add("FAILURE[" + DateTime.Now + "] Name: " + manga_name + " | Chapter: " + chapter_dir + " | Page: " + i + " of " + page_end);
                }
            }
            log.Add("SUCCESS[" + DateTime.Now + "] Name: " + manga_name + " | Chapter: " + chapter_dir + " | Page: " + page_start + " through " + page_end);
        }
        public static void Print(string text, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        private static byte[] ScaleImage(byte[] buffer, int max_width, int max_height)
        {
            MemoryStream stream = new MemoryStream(buffer);
            Image image = ScaleImage(Image.FromStream(stream), max_width, max_height);
            image.Save(stream = new MemoryStream(), ImageFormat.Jpeg);
            return stream.ToArray();
        }
        private static Image ScaleImage(Image image, int max_width, int max_height)
        {
            double ratio_x = (double)max_width / image.Width;
            double ratio_y = (double)max_height / image.Height;
            double ratio = Math.Min(ratio_x, ratio_y);

            int new_width = (int)(image.Width * ratio);
            int new_height = (int)(image.Height * ratio);

            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics.FromImage(new_image).DrawImage(image, 0, 0, new_width, new_height);

            return new_image;
        }
    }
}