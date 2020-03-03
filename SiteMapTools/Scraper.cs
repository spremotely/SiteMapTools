using System.Net;
using SiteMapTools.Exceptions;
using SiteMapTools.Models;

namespace SiteMapTools
{
    internal class Scraper
    {
        private readonly string _targetUrl;

        public Scraper(string targetUrl)
        {
            this._targetUrl = targetUrl;
        }

        public SiteMap Scrap()
        {
            var xmlString = GetXmlString(this._targetUrl);

            return string.IsNullOrEmpty(xmlString) ? new SiteMap() : new Parser(xmlString).Parse();
        }

        private static string GetXmlString(string targetUrl)
        {
            var webClient = new WebClient();

            try
            {
                return webClient.DownloadString(targetUrl);
            }
            catch (WebException e)
            {
                var exception = new ScraperException("cannot scrap this url", e);
                throw exception;
            }
        }
    }
}
