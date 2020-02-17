using System.Collections.Generic;
using SiteMapScraper.Models;

namespace SiteMapTools.Models
{
    public class HierarchicalSiteMapEntry : SiteMapEntry
    {
        public HierarchicalSiteMapEntry Parent { get; set; }
        public List<HierarchicalSiteMapEntry> Children { get; set; } = new List<HierarchicalSiteMapEntry>();

        public HierarchicalSiteMapEntry(SiteMapEntry entry)
        {
            this.ChangeFrequency = entry.ChangeFrequency;
            this.Priority = entry.Priority;
            this.Location = entry.Location;
            this.LastModifiedDate = entry.LastModifiedDate;
        }

        public override int GetHashCode()
        {
            return this.Location.GetHashCode();
        }
    }
}
