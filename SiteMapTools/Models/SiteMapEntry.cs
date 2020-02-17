using System;

namespace SiteMapScraper.Models
{
    public class SiteMapEntry
    {
        public string Location { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public decimal Priority { get; set; }
        public string ChangeFrequency { get; set; }
    }
}
