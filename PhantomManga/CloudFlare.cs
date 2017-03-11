using CloudFlareUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhantomManga
{
    public static class CloudFlare
    {
        // Variables
        private static ClearanceHandler handler = new ClearanceHandler() { MaxRetries = 2 };
        public static HttpClient client = new HttpClient(handler);

        // Methods
        public static string GetSource(string url)
        {
            return Task.Run<string>(() => client.GetStringAsync(url)).Result;
        }
        public static Stream GetStream(string url)
        {
            return Task.Run<Stream>(() => client.GetStreamAsync(url)).Result;
        }
    }
}