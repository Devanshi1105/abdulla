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
    public partial class chatted : ContentPage
    {
        string xmobilex;
        public chatted(string xmobile)
        {
            InitializeComponent();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#ED8037");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
            xmobilex = xmobile;
            GetServices();
        }
        private async void GetServices()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://workshopksa.com/api/chatts/search/" + xmobilex + "");
            var xservicelist = JsonConvert.DeserializeObject<List<servicesusers>>(response);

            chattedlst.ItemsSource = xservicelist;
        }
        //private async Task Chattedlst_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        //{
        //    var selectedItem = e.Item as xusersTs;

        //    await Navigation.PushAsync(new chatPage(xmobilex,selectedItem.ToString()));

        //}

        private void Chattedlst_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as chatTs;
      
                Navigation.PushAsync(new chatPage(xmobilex, selectedItem.wsmobile));

        }
    }
}