using System;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace DovreKommune
{
	public static class RssDownloader
	{
		public static List<RssItem> DownloadRSS (string url)
		{
			XDocument feedXML = XDocument.Load(url);

			var feeds = from feed in feedXML.Descendants("item")
				select new RssItem
			{
				Title = feed.Element("title").Value,
				Link = feed.Element("link").Value,
				Description = feed.Element("description").Value
			};

			return feeds.ToList();
		}

		public class RssItem 
		{
			public string Title;
			public string Link;
			public string Description;
		}
	}
}
