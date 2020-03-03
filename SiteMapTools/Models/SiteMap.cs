using System.Collections.Generic;
using System.Linq;
using SiteMapTools.Common;

namespace SiteMapTools.Models
{
    public class SiteMap
    {
        public List<SiteMapEntry> Entries { get; set; } = new List<SiteMapEntry>();

        public static SiteMap Scrap(string targetUrl)
        {
            var scraper = new Scraper(targetUrl);
            return scraper.Scrap();
        }

        public static SiteMap Parse(string siteMap)
        {
            var parser = new Parser(siteMap);
            return parser.Parse();
        }

        public SiteMap Except(SiteMap siteMap)
        {
            return new SiteMap
            {
                Entries = this.Entries.Except(siteMap.Entries, new SiteMapEntryComparer()).ToList()
            };
        }
    }
}
