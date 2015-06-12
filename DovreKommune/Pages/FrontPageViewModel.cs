using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DovreKommune
{
	public class FrontPageViewModel : INotifyPropertyChanged
	{


		ObservableCollection<DovreKommune.RssDownloader.RssItem> _items;
		public ObservableCollection<DovreKommune.RssDownloader.RssItem> Items{
			get {
				return _items;
			}
			set {
				_items = value;
				OnPropertyChanged ();
			}
		}


		public FrontPageViewModel()
		{
			//Henter elementer fra rss feed
			var rssItems = RssDownloader.DownloadRSS("http://www.sel.kommune.no/rss");
			Items = rssItems;
		}


		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

