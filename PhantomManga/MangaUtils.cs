using CloudFlareUtilities;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhantomManga
{
    public static class MangaUtils
    {
        /// <summary>
        /// Delete all chapters, pages and metadata for a specific series.
        /// </summary>
        /// <param name="mfcode">Series MF Code</param>
        public static void DeleteManga(string mfcode)
        {
            Directory.Delete("data\\" + mfcode, true);
        }

        /// <summary>
        /// Convert series name to a usable RC code.
        /// </summary>
        /// <param name="seriesname">Series Name</param>
        /// <returns>RC Code corresponding to the series title</returns>
        public static string GetMFCode(string seriesname)
        {
            return seriesname.Replace("!", "").Replace("#", "").Replace("%", "").Replace("&", "").Replace("(", "").Replace(")", "").Replace(" - ", "_").Replace("-", "_").Replace("+", "_").Replace("[", "").Replace("{", "").Replace("]", "").Replace("}", "").Replace(";", "").Replace(":", "").Replace("'", "").Replace("\"", "").Replace(",", "").Replace("<", "").Replace(".", "").Replace("/", "_").Replace("?", "").Replace("  ", "_").Replace(" ", "_").ToLower();
        }

        /// <summary>
        /// Parse the Manga page and read back the URL for the Manga banner.
        /// </summary>
        /// <param name="mfcode">Series MF Code</param>
        /// <param name="shtml">Saved HTML</param>
        /// <returns>Manga banner URL</returns>
        public static string RetrieveBanner(string mfcode, string shtml = "")
        {
            // Grab page source
            string html = shtml == "" ? CloudFlare.GetSource("http://www.mangafreak.net/Manga/" + mfcode) : shtml;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Parse page source
            string loc = "";
            foreach (HtmlNode node in doc.DocumentNode.Descendants())
                if (node.Name == "div")
                    if (node.GetAttributeValue("class", "") == "manga_series_image")
                        loc = node.OuterHtml.Split(new string[] { "src=\"" }, StringSplitOptions.None)[1].Split(new char[] { '\"' })[0];

            // Return
            return loc;
        }
        /// <summary>
        /// Find and parse a random chapter and read back a list of all hosted chapters.
        /// </summary>
        /// <param name="mfcode">Series MF Code</param>
        /// <returns>The complete chapter list in the specified Manga series</returns>
        public static string[] RetrieveChapterList(string mfcode)
        {
            // Grab page source
            string html = CloudFlare.GetSource("http://www.mangafreak.net/Manga/" + mfcode);

            //blablabla

            return null;
        }
        /// <summary>
        /// Parse the Manga page and read back the description for the Manga.
        /// </summary>
        /// <param name="mfcode">Series MF Code</param>
        /// <param name="shtml">Saved HTML</param>
        /// <returns>Manga description</returns>
        public static string RetrieveDescription(string mfcode, string shtml = "")
        {
            // Grab page source
            string html = shtml == "" ? CloudFlare.GetSource("http://www.mangafreak.net/Manga/" + mfcode) : shtml;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Parse page source
            string desc = "";
            foreach (HtmlNode node in doc.DocumentNode.Descendants())
                if (node.Name == "div")
                    if (node.GetAttributeValue("class", "") == "manga_series_description")
                        desc = node.InnerText.Replace("\nManga Description\n", "").TrimEnd(new char[] { '\n' });

            // Return
            return desc;
        }
        /// <summary>
        /// Parse the chapter page and read back the page count.
        /// </summary>
        /// <param name="mfcode">Series MF Code</param>
        /// <param name="chapter">Chapter (ex: 1, 3, 5.1, 15-3, etc..)</param>
        /// <returns>The amount of pages in the specified chapter</returns>
        public static int RetrievePageCount(string mfcode, string chapter)
        {
            try
            {
                // Grab page source
                string html = CloudFlare.GetSource("http://www.mangafreak.net/Read1_" + mfcode + "_" + chapter);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                // Parse page source
                int res = 0;
                foreach (HtmlNode node in doc.DocumentNode.Descendants())
                    if (node.Name == "div")
                        if (node.GetAttributeValue("class", "") == "read_selector")
                            res = int.Parse(node.InnerText.Split(new char[] { ' ' })[1]);

                // Return
                if (res != 0)
                    return res;
                return (int)ChapterFailReason.UnableToReadPageCount;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("(404)"))
                    return (int)ChapterFailReason.DoesntExist;
                return (int)ChapterFailReason.Unknown;
            }
        }
    }
}