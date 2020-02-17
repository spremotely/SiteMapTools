# SiteMapTools
.Net Standard library for sitemap manipulating

## Usage

```C#
// for parsing
var siteMap = SiteMap.Parse(File.ReadAllTest("yoursitemap.xml"));

// for parsing from website by direct url
var siteMap = SiteMap.Scrap("https://www.sitemaps.org/sitemap.xml");

// you can transform site map to hierarchical object with:
var hierarchicalSiteMap = siteMap.ToHierarchical();
