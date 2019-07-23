using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ws01.pages.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ws01.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ServiceType : ContentPage
	{
		public ServiceType ()
		{
			//InitializeComponent ();
            Title = "نوع الخدمة";

            NavigationPage.SetHasBackButton(this, false);

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#ED8037");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }

        public async void ListfillAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://workshopksa.com/api/xservicests");
            var xservicelist = JsonConvert.DeserializeObject<List<xusersTs>>(response);

           // xlists.ItemsSource = xservicelist;
        }

        private async Task btnnext_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new pages.wantedservice());
        }

        private void btnnext_Clicked(object sender, EventArgs e)
        {

        }
    }
}