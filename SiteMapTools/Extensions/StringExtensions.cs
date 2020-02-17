using System.Linq;

namespace SiteMapScraper.Extensions
{
    internal static class StringExtensions
    {
        public static string PreviousUrl(this string location)
        {
            var locationParts = location.Split('/');
            locationParts = locationParts.Take(locationParts.Length - 1).ToArray();
            return string.Join("/", locationParts);
        }
    }
}
