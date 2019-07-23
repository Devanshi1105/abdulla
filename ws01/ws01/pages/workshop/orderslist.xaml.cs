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

namespace ws01.pages.workshop
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class orderslist : ContentPage
	{
		public orderslist ()
		{
			InitializeComponent ();
            Title = "الطلبات";

            GetOrders();
            activityIndicator.IsRunning = activityIndicator.IsRunning;

            NavigationPage.SetHasBackButton(this, false);
            //ListfillAsync();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#ED8037");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }

     
        private async void GetOrders()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://workshopksa.com/api/xorderts");
            var xservicelist = JsonConvert.DeserializeObject<List<order>>(response);

            serviceslist.ItemsSource = xservicelist;

        }

        private async Task serviceslist_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            
            await Navigation.PushAsync(new pages.workshop.placeoffer());
            
            
        }
    }
}