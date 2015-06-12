using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DovreKommune
{
	public partial class FrontPage : ContentPage
	{
		public FrontPage ()
		{
			InitializeComponent ();
			this.Title = "Hjem";

			var rssItems = RssDownloader.DownloadRSS("http://www.sel.kommune.no/rss");

		}
	}
}
	