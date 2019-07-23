using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ws01.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class wantedservice : ContentPage
	{
		public wantedservice ()
		{
			InitializeComponent ();
            Title = "الخدمة المطلوبة";
            NavigationPage.SetHasBackButton(this, false);
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#ED8037");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;

        }
	}
}