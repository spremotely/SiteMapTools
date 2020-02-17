using System.Collections.Generic;
using System.Linq;
using SiteMapScraper.Extensions;
using SiteMapScraper.Models;
using SiteMapTools.Models;

namespace SiteMapTools.Builders
{
    internal static class HierarchicalSiteMapBuilder
    {
        public static HierarchicalSiteMapEntry Build(SiteMap siteMap)
        {
            var processedEntries = new HashSet<HierarchicalSiteMapEntry>();

            foreach (var nextEntry in siteMap.Entries)
            {
                var newEntry = new HierarchicalSiteMapEntry(nextEntry);

                var parentEntry = siteMap.Entries
                    .FirstOrDefault(e =>
                        e.Location.TrimEnd('/') == newEntry.Location.TrimEnd('/').PreviousUrl());

                if (parentEntry == null)
                {
                    processedEntries.Add(newEntry);
                    continue;
                }

                var parentNewEntry = processedEntries
                    .FirstOrDefault(e => 
                        e.Location.TrimEnd('/') == newEntry.Location.TrimEnd('/').PreviousUrl());

                if (parentNewEntry != null)
                {
                    parentNewEntry.Children.Add(newEntry);
                    newEntry.Parent = parentNewEntry;
                    processedEntries.Add(newEntry);
                    continue;
                }

                parentNewEntry = new HierarchicalSiteMapEntry(parentEntry);
                parentNewEntry.Children.Add(newEntry);
                newEntry.Parent = parentNewEntry;
                processedEntries.Add(newEntry);
            }

            return processedEntries.FirstOrDefault(e => e.Parent == null);
        }
    }
}
