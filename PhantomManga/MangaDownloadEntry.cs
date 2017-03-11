using System;
using System.Text;

namespace PhantomManga
{
    public struct MangaDownloadEntry
    {
        public int chapter_num;
        public int chapter_ad;
        public bool chapter_hasdec;
        public bool chapter_hashyp;
        public string manga_name;
        public string manga_rccode;
        public int page_start;
        public int page_end;
        public bool resize;
    }
}