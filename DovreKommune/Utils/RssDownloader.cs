using System;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace DovreKommune
{
	public static class RssDownloader
	{
		public static ObservableCollection<RssItem> DownloadRSS (string url)
		{
			XDocument feedXML = XDocument.Load(url);

			var feeds = from feed in feedXML.Descendants("item")
				select new RssItem
			{
				Title = feed.Element("title").Value,
				Link = feed.Element("link").Value,
				Description = feed.Element("description").Value
			};

			return new ObservableCollection<RssItem>(feeds.ToList());
		}

		public class RssItem : INotifyPropertyChanged
		{
			string _title = "";
			public string Title{
				set 
				{
					_title = value;
					OnPropertyChanged ();
				}
				get 
				{
					return _title;
				}
			}

			string _Link = "";
			public string Link{
				set 
				{
					_Link = value;
					OnPropertyChanged ();
				}
				get 
				{
					return _Link;
				}
			}

			string _Description = "";
			public string Description{
				set 
				{
					_Description = value;
					OnPropertyChanged ();
				}
				get 
				{
					return _Description;
				}
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

		public interface INotifyPropertyChanged
		{
			event PropertyChangedEventHandler PropertyChanged;
		}
	}
}
