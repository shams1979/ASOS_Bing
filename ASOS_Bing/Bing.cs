using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASOS_Bing.Interface;
using System.Net;

namespace ASOS_Bing
{
    public class Bing
    {
        private IUrlFetcher urlFetcher;
        public string url { get; set; }
        public string searchString { get; set; }

        public Bing(IUrlFetcher urlfetcher, string url, string search)
        {
            this.urlFetcher = urlfetcher;
            this.url = url;
            this.searchString = search;
        }

        public string GenerateUrlWithParams()
        {
            return String.Concat(url, "/search?q=", searchString);
        }

        public HttpStatusCode RunSearch()
        {
            return urlFetcher.RunSearch(GenerateUrlWithParams());
        }

        public HttpStatusCode RunSearch(int times)
        {
            if (times < 1)
                throw new IndexOutOfRangeException();

            while (times > 0)
            {
                var code = RunSearch();
                if (code != HttpStatusCode.OK)
                {
                    return code;
                }

                times--;
            }

            return HttpStatusCode.OK;
        }
    }
}
