using CloudFlareUtilities;
using HtmlAgilityPack;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhantomManga
{
    public partial class frmImport : MaterialForm
    {
        // Variables
        Dictionary<string, string> manga_list = new Dictionary<string, string>();

        // Constructor
        public frmImport()
        {
            // Draw frmImport
            InitializeComponent();
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.DARK;
            manager.ColorScheme = new ColorScheme(Primary.Orange400, Primary.Grey900, 0, Accent.Orange200, TextShade.BLACK);

            // Setup
            search_text.KeyPress += search_text_KeyPress;
            string buffer = new WebClient().DownloadString("http://pastebin.com/raw/0VzWc6R9");
            string[] mangas = buffer.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (string Manga in mangas)
                manga_list.Add(Manga, MangaUtils.GetMFCode(Manga));
        }

        // MaterialSingleLineTextField Events
        private void search_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                search_Click(0, new EventArgs());
        }

        // MaterialRaisedButton Events
        private void manga_save_Click(object sender, EventArgs e)
        {
            // Check if Manga is already saved
            if (!Directory.Exists("data\\" + manga_list[manga_name.Text]))
            {
                // Create directory
                Directory.CreateDirectory("data\\" + manga_list[manga_name.Text]);

                // Save metadata
                File.WriteAllText("data\\" + manga_list[manga_name.Text] + "\\detail.txt", manga_name.Text);
                File.WriteAllText("data\\" + manga_list[manga_name.Text] + "\\desc.txt", manga_description.Text);

                // Save banner
                Bitmap bmp = new Bitmap(manga_picture.BackgroundImage);
                bmp.Save("data\\" + manga_list[manga_name.Text] + "\\banner.jpg");
            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            // Setup
            string query = search_text.Text.ToLower();
            string[] keys = manga_list.Keys.ToArray();
            search_results.Items.Clear();

            // Search
            foreach (string key in keys)
                if (key.ToLower().Contains(query))
                    search_results.Items.Add(key);
        }

        // ListBox Events
        private void search_results_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Setup
            if (search_results.SelectedIndex < 0) return;
            string key = search_results.GetItemText(search_results.SelectedItem);
            string value = manga_list[key];
            string url = "http://www.mangafreak.net/Manga/" + value;
            manga_description.Text = "Fetching manga description..";
            manga_name.Text = key;

            // Grab page source
            string html = CloudFlare.GetSource("http://www.mangafreak.net/Manga/" + value);

            // Get description
            manga_description.Text = MangaUtils.RetrieveDescription(value, html);

            // Get banner
            string loc = MangaUtils.RetrieveBanner(value, html);
            Stream stream = CloudFlare.GetStream(loc);
            Image banner = Image.FromStream(stream);
            manga_picture.BackgroundImage = banner;
        }
    }
}