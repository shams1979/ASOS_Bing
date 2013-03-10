using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ASOS_Bing.Interface
{
    public interface IUrlFetcher
    {
        HttpStatusCode RunSearch(string url);
    }
}
