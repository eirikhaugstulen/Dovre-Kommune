using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DovreKommune
{
	public partial class FrontPage : ContentPage
	{
		
		public FrontPage ()
		{
			InitializeComponent ();
			this.Title = "Hjem";
			listView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
				DovreKommune.RssDownloader.RssItem item = (DovreKommune.RssDownloader.RssItem)e.SelectedItem;
				Debug.WriteLine ("Klikket på element: " + item.Link);

				this.Navigation.PushAsync(new ViewRssLink(item.Link));
			};


		}



	}
}
	