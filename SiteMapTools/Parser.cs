using System;
using System.Globalization;
using System.Linq;
using System.Xml;
using SiteMapTools.Models;

namespace SiteMapTools
{
    internal class Parser
    {
        private readonly string _xmlString;

        public Parser(string xmlString)
        {
            this._xmlString = xmlString;
        }

        public SiteMap Parse()
        {
            return string.IsNullOrEmpty(_xmlString) ? new SiteMap() : DeserializeXmlString(_xmlString);
        }

        private static SiteMap DeserializeXmlString(string xmlString)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);
            var nodeList = xmlDocument.GetElementsByTagName("url");
            var siteMap = new SiteMap();

            foreach (XmlNode node in nodeList)
            {
                siteMap.Entries.Add(new SiteMapEntry
                {
                    Location = node["loc"]?.InnerText,
                    Priority = Convert.ToDecimal(node["priority"]?.InnerText, new CultureInfo("en-US")),
                    LastModifiedDate = Convert.ToDateTime(node["lastmod"]?.InnerText),
                    ChangeFrequency = node["changefreq"]?.InnerText
                });
            }

            siteMap.Entries = siteMap.Entries.OrderBy(e => e.Location.Split('/').Length).ToList();

            return siteMap;
        }
    }
}
