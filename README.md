# SiteMapTools
.Net Standard library for sitemap manipulating - parse and scrap - enjoy!

## Usage

```C#
// for parsing
var siteMap = SiteMap.Parse(File.ReadAllTest("yoursitemap.xml"));

// for pasing from website by direct url
var siteMap = SiteMap.Scrap("https://www.sitemaps.org/sitemap.xml");

// you can transform site map to hierarchical object with:
var hierarchicalSiteMap = siteMap.ToHierarchical();
