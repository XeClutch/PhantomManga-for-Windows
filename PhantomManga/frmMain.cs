using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace PhantomManga
{
    public partial class frmMain : MaterialForm
    {
        // Variables
        List<string> mangas_list = new List<string>();
        string credits_link;
        string[] credits_messages = { "Application by Joshua Ozeri. Controls by Igance Maes. Icon by Cleberman Kalangozilla. mangas hosted on mangafreak.net",
                                                "If you like a manga support it financially so it can continue to run!",
                                                "Donate to the application developer for continued development of this project and many others!<|>http://www.paypal.me/papajoshu",
                                                "This project is now open source!<|>http://www.github.com/xeclutch/phantommanga-for-windows" };
        Thread credits_thread;
        int curpage = 0;
        Thread download_thread;

        // Threads
        private void CreditsUpdate()
        {
            int cnt = 0;
            int i = 0;
            string[] queue;
            if (IsOnline())
                queue = new WebClient().DownloadString("http://pastebin.com/raw/hE9F8Wkk").Split(new char[] { '\n' });
            else
                queue = credits_messages;

            while (credits_thread.ThreadState == ThreadState.Running)
            {
                if (i == 0)
                {
                    cnt = queue.Length;
                }

                string[] split = queue[i].Split(new string[] { "<|>" }, StringSplitOptions.None);
                if (split.Length > 1)
                {
                    credits.Cursor = Cursors.Hand;
                    credits.Text = split[0];
                    credits_link = split[1];
                }
                else
                {
                    credits.Cursor = Cursors.Arrow;
                    credits.Text = split[0];
                    credits_link = "";
                }

                Thread.Sleep(6000);
                i++;
                if (i == cnt)
                    i = 0;
            }
        }

        // Methods
        private bool IsOnline()
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send("google.com", 1000, new byte[32], new PingOptions());
            return reply.Status == IPStatus.Success;
        }
        private void RefreshList(int page = 0)
        {
            mangas_list.Clear();
            string[] mangas_series = Directory.GetDirectories("data\\");
            for (int i = 0; i < mangas_series.Length; i++)
                mangas_list.Add(File.ReadAllText(mangas_series[i] + "\\detail.txt"));
            if ((mangas_series.Length - (page * 6)) > 0)
            {
                FileStream manga1_stream = new FileStream(mangas_series[page * 6] + "\\banner.jpg", FileMode.Open, FileAccess.Read);
                manga1_picture.BackgroundImage = Image.FromStream(manga1_stream);
                manga1_stream.Dispose();
                manga1_name.Text = mangas_list[page * 6];
                if ((mangas_series.Length - (page * 6)) > 1)
                {
                    FileStream manga2_stream = new FileStream(mangas_series[(page * 6) + 1] + "\\banner.jpg", FileMode.Open, FileAccess.Read);
                    manga2_picture.BackgroundImage = Image.FromStream(manga2_stream);
                    manga2_stream.Dispose();
                    manga2_name.Text = mangas_list[(page * 6) + 1];
                    if ((mangas_series.Length - (page * 6)) > 2)
                    {
                        FileStream manga3_stream = new FileStream(mangas_series[(page * 6) + 2] + "\\banner.jpg", FileMode.Open, FileAccess.Read);
                        manga3_picture.BackgroundImage = Image.FromStream(manga3_stream);
                        manga3_stream.Dispose();
                        manga3_name.Text = mangas_list[(page * 6) + 2];
                        if ((mangas_series.Length - (page * 6)) > 3)
                        {
                            FileStream manga4_stream = new FileStream(mangas_series[(page * 6) + 3] + "\\banner.jpg", FileMode.Open, FileAccess.Read);
                            manga4_picture.BackgroundImage = Image.FromStream(manga4_stream);
                            manga4_stream.Dispose();
                            manga4_name.Text = mangas_list[(page * 6) + 3];
                            if ((mangas_series.Length - (page * 6)) > 4)
                            {
                                FileStream manga5_stream = new FileStream(mangas_series[(page * 6) + 4] + "\\banner.jpg", FileMode.Open, FileAccess.Read);
                                manga5_picture.BackgroundImage = Image.FromStream(manga5_stream);
                                manga5_stream.Dispose();
                                manga5_name.Text = mangas_list[(page * 6) + 4];
                                if ((mangas_series.Length - (page * 6)) > 5)
                                {
                                    FileStream manga6_stream = new FileStream(mangas_series[(page * 6) + 5] + "\\banner.jpg", FileMode.Open, FileAccess.Read);
                                    manga6_picture.BackgroundImage = Image.FromStream(manga6_stream);
                                    manga6_stream.Dispose();
                                    manga6_name.Text = mangas_list[(page * 6) + 5];
                                }
                                else
                                {
                                    manga6_name.Text = "No Manga";
                                    manga6_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga6_picture.BackgroundImage")));
                                }
                            }
                            else
                            {
                                manga5_name.Text = "No Manga";
                                manga5_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga5_picture.BackgroundImage")));
                                manga6_name.Text = "No Manga";
                                manga6_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga6_picture.BackgroundImage")));
                            }
                        }
                        else
                        {
                            manga4_name.Text = "No Manga";
                            manga4_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga4_picture.BackgroundImage")));
                            manga5_name.Text = "No Manga";
                            manga5_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga5_picture.BackgroundImage")));
                            manga6_name.Text = "No Manga";
                            manga6_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga6_picture.BackgroundImage")));
                        }
                    }
                    else
                    {
                        manga3_name.Text = "No Manga";
                        manga3_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga3_picture.BackgroundImage")));
                        manga4_name.Text = "No Manga";
                        manga4_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga4_picture.BackgroundImage")));
                        manga5_name.Text = "No Manga";
                        manga5_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga5_picture.BackgroundImage")));
                        manga6_name.Text = "No Manga";
                        manga6_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga6_picture.BackgroundImage")));
                    }
                }
                else
                {
                    manga2_name.Text = "No Manga";
                    manga2_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga2_picture.BackgroundImage")));
                    manga3_name.Text = "No Manga";
                    manga3_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga3_picture.BackgroundImage")));
                    manga4_name.Text = "No Manga";
                    manga4_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga4_picture.BackgroundImage")));
                    manga5_name.Text = "No Manga";
                    manga5_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga5_picture.BackgroundImage")));
                    manga6_name.Text = "No Manga";
                    manga6_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("manga6_picture.BackgroundImage")));
                }
            }
        }

        // Constructor
        public frmMain()
        {
            // Version Check
            string[] updatebuffer = new WebClient().DownloadString("http://pastebin.com/raw/LnnDuE1M").Split(new string[] { "\r\n" }, StringSplitOptions.None);
            Version currentversion = Assembly.GetEntryAssembly().GetName().Version;
            Version latestversion = Version.Parse(updatebuffer[0]);
            string changes = "";
            for (int i = 2; i < updatebuffer.Length; i++)
            {
                changes += updatebuffer[i];
                if (i != updatebuffer.Length)
                    changes += "\n";
            }
            if (currentversion < latestversion)
            {
                new MaterialMessageBox("Update Available", "There is an update available!\n\nCurrent Version: " + currentversion.ToString() + "\nUpdated Version: " + latestversion.ToString() + "\n\nYou will now be taken to the update download.").ShowDialog();
                System.Diagnostics.Process.Start(updatebuffer[1]);
                this.Close();
            }

            // Site check
            try
            {
                CloudFlare.GetSource("http://www.mangafreak.net");
            }
            catch
            {
                new MaterialMessageBox("Site Down", "MangaFreak is currently down. You can still read your comics but you will not be able to download any until the site comes back online.").ShowDialog();
            }

            // Draw frmMain
            InitializeComponent();
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.DARK;
            manager.ColorScheme = new ColorScheme(Primary.Orange400, Primary.Grey900, 0, Accent.Orange200, TextShade.BLACK);

            // Setup
            CheckForIllegalCrossThreadCalls = false;
            FormClosing += frmMain_FormClosing;
            downloadcontrol.Font = new Font("Roboto", 8f, FontStyle.Regular);
            credits.Font = new Font("Roboto", 8f, FontStyle.Regular);
            credits_thread = new Thread(CreditsUpdate);
            credits_thread.Start();
            download_thread = new Thread(DownloadAssistant.Downloader);
            download_thread.Start();
            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");
            RefreshList();
            Thread.Sleep(10);
            DownloadAssistant.Print("\n\nChanges made to this version (" + currentversion.ToString() + "):\n" + changes);

            downloadcontrol_pause.BackgroundImage.Save("pause.png");
            downloadcontrol_play.BackgroundImage.Save("play.png");
            downloadcontrol_stop.BackgroundImage.Save("stop.png");
        }

        // Form Events
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            credits_thread.Abort();
            Application.Exit();
        }

        // MaterialContextMenuStrip Events
        private void manga1_context_delete_Click(object sender, EventArgs e)
        {
            MangaUtils.DeleteManga(MangaUtils.GetMFCode(mangas_list[curpage * 6]));
            RefreshList(curpage);
        }
        private void manga1_context_download_Click(object sender, EventArgs e)
        {
            new frmDownload(MangaUtils.GetMFCode(mangas_list[curpage * 6])).ShowDialog();
        }
        private void manga1_context_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data\\" + MangaUtils.GetMFCode(mangas_list[curpage * 6]) + "\\Manga"))
                new frmViewer(MangaUtils.GetMFCode(mangas_list[curpage * 6])).ShowDialog();
            else
                new MaterialMessageBox("Error", "In order to read this Manga you must first download parts of it.").ShowDialog();
        }
        private void manga2_context_delete_Click(object sender, EventArgs e)
        {
            MangaUtils.DeleteManga(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 1]));
            RefreshList(curpage);
        }
        private void manga2_context_download_Click(object sender, EventArgs e)
        {
            new frmDownload(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 1])).ShowDialog();
        }
        private void manga2_context_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data\\" + MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 1]) + "\\Manga"))
                new frmViewer(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 1])).ShowDialog();
            else
                new MaterialMessageBox("Error", "In order to read this Manga you must first download parts of it.").ShowDialog();
        }
        private void manga3_context_delete_Click(object sender, EventArgs e)
        {
            MangaUtils.DeleteManga(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 2]));
            RefreshList(curpage);
        }
        private void manga3_context_download_Click(object sender, EventArgs e)
        {
            new frmDownload(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 2])).ShowDialog();
        }
        private void manga3_context_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data\\" + MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 2]) + "\\Manga"))
                new frmViewer(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 2])).ShowDialog();
            else
                new MaterialMessageBox("Error", "In order to read this Manga you must first download parts of it.").ShowDialog();
        }
        private void manga4_context_delete_Click(object sender, EventArgs e)
        {
            MangaUtils.DeleteManga(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 3]));
            RefreshList(curpage);
        }
        private void manga4_context_download_Click(object sender, EventArgs e)
        {
            new frmDownload(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 3])).ShowDialog();
        }
        private void manga4_context_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data\\" + MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 3]) + "\\Manga"))
                new frmViewer(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 3])).ShowDialog();
            else
                new MaterialMessageBox("Error", "In order to read this Manga you must first download parts of it.").ShowDialog();
        }
        private void manga5_context_delete_Click(object sender, EventArgs e)
        {
            MangaUtils.DeleteManga(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 4]));
            RefreshList(curpage);
        }
        private void manga5_context_download_Click(object sender, EventArgs e)
        {
            new frmDownload(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 4])).ShowDialog();
        }
        private void manga5_context_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data\\" + MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 4]) + "\\Manga"))
                new frmViewer(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 4])).ShowDialog();
            else
                new MaterialMessageBox("Error", "In order to read this Manga you must first download parts of it.").ShowDialog();
        }
        private void manga6_context_delete_Click(object sender, EventArgs e)
        {
            MangaUtils.DeleteManga(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 5]));
            RefreshList(curpage);
        }
        private void manga6_context_download_Click(object sender, EventArgs e)
        {
            new frmDownload(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 5])).ShowDialog();
        }
        private void manga6_context_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data\\" + MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 5]) + "\\Manga"))
                new frmViewer(MangaUtils.GetMFCode(mangas_list[(curpage * 6) + 5])).ShowDialog();
            else
                new MaterialMessageBox("Error", "In order to read this Manga you must first download parts of it.").ShowDialog();
        }

        // PictureBox Events
        private void getplex_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.github.com/xeclutch/phantommanga.bundle");
        }
        private void mangas_previous_Click(object sender, EventArgs e)
        {
            if (curpage > 0)
            {
                curpage--;
                RefreshList(curpage);
            }
        }
        private void mangas_next_Click(object sender, EventArgs e)
        {
            if (curpage < (mangas_list.Count - 1) / 6)
            {
                curpage++;
                RefreshList(curpage);
            }
        }
        private void downloadcontrol_play_Click(object sender, EventArgs e)
        {
            DownloadAssistant.state = DownloadState.Free;
            new MaterialMessageBox("Download Control", "All downloads will continue as scheduled.").ShowDialog();
        }
        private void downloadcontrol_pause_Click(object sender, EventArgs e)
        {
            DownloadAssistant.state = DownloadState.Restricted;
            new MaterialMessageBox("Download Control", "All downloads will pause until you force them to resume.").ShowDialog();
        }
        private void downloadcontrol_stop_Click(object sender, EventArgs e)
        {
            DownloadAssistant.state = DownloadState.Killed;
            new MaterialMessageBox("Download Control", "All downloads will cease once the current download has finished.").ShowDialog();
        }

        // MaterialRaisedButton Events
        private void mangas_import_Click(object sender, EventArgs e)
        {
            new frmImport().ShowDialog();
            RefreshList(curpage);
        }

        // Label Events
        private void credits_Click(object sender, EventArgs e)
        {
            if (credits_link != "")
                System.Diagnostics.Process.Start(credits_link);
        }
    }
}