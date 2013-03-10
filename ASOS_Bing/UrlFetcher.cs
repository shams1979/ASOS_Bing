using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASOS_Bing.Interface;
using System.Net;

namespace ASOS_Bing
{
    public class UrlFetcher : IUrlFetcher
    {
        public UrlFetcher()
        { }

        public HttpStatusCode RunSearch(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return HttpStatusCode.OK;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.Timeout)
                    return HttpStatusCode.RequestTimeout;

                var resp = (HttpWebResponse)ex.Response;
                return resp.StatusCode;
            } 
        }
    }
}
