using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ASOS_Bing;
using ASOS_Bing.Interface;
using System.Net;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASOS_Bing_Tests
{
    [TestClass]
    public class BingTest
    {
        Bing bing;
        private string searchurl = "http://www.bing.com/";
        private string searchquery = "hello";

        [TestInitialize]
        public void Init()
        {            
            IUrlFetcher fetcher = new UrlFetcher();
            bing = new Bing(fetcher, searchurl, searchquery);
        }

        [TestMethod]
        public void VerifyCorrect_Url()
        {
            Assert.AreEqual(searchurl, bing.url);
        }

        [TestMethod]
        public void VerifyCorrect_SearchString()
        {
            Assert.AreEqual(searchquery, bing.searchString);
        }

        [TestMethod]
        public void VerifyCorrectSearchUrlWithParams()
        {
            Assert.AreEqual(String.Concat(searchurl, "/search?q=", searchquery), bing.GenerateUrlWithParams());
        }

        [TestMethod]
        public void RunSearchVerifyOKStatus()
        {
            Assert.AreEqual(HttpStatusCode.OK, bing.RunSearch());
        }

        [TestMethod]
        public void RunSearch_Capture_ServiceUnavailable_Error()
        {
            Mock<IUrlFetcher> search = new Mock<IUrlFetcher>();
            search.Setup(x => x.RunSearch(It.IsAny<string>())).Returns(HttpStatusCode.ServiceUnavailable);
            bing = new Bing(search.Object, searchurl, searchquery);

            Assert.AreEqual(HttpStatusCode.ServiceUnavailable, bing.RunSearch());
        }

        [TestMethod]
        public void Run_Search_100_Times()
        {
            bing.RunSearch(100);
        }                
    }
}
