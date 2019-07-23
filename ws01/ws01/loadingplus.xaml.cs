using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ws01
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class loadingplus : PopupPage
    {
		public loadingplus ()
		{
			InitializeComponent ();
		}

     

        public static async void CloseAllPopup()
        {
            
            await App.Current.MainPage.Navigation.PopAllPopupAsync(true);
        }
    }
}