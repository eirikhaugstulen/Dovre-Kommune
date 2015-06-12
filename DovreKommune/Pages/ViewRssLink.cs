using System;

using Xamarin.Forms;

namespace DovreKommune
{
	public class ViewRssLink : ContentPage
	{
		public ViewRssLink (string url)
		{
			Content = new StackLayout { 
				Children = {
					new WebView { Source = url }
				}
			};
		}

		public class BaseUrlWebView : WebView { }
	}
}


