using System;
using System.Collections.Generic;
using SiteMapTools.Models;

namespace SiteMapTools.Common
{
    internal class SiteMapEntryComparer : IEqualityComparer<SiteMapEntry>
    {
        public bool Equals(SiteMapEntry x, SiteMapEntry y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }

            return x.Location == y.Location && x.LastModifiedDate == y.LastModifiedDate;
        }

        public int GetHashCode(SiteMapEntry obj)
        {
            var locationHash = obj.Location == null ? 0 : obj.Location.GetHashCode();
            var lastModifiedHash = obj.LastModifiedDate.GetHashCode();

            return locationHash ^ lastModifiedHash;
        }
    }
}
