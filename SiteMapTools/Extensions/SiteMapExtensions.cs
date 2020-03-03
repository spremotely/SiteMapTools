using SiteMapTools.Common;
using SiteMapTools.Models;

namespace SiteMapTools.Extensions
{
    public static class SiteMapExtensions
    {
        public static HierarchicalSiteMapEntry ToHierarchical(this SiteMap siteMap)
        {
            return HierarchicalSiteMapBuilder.Build(siteMap);
        }
    }
}
