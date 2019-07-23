using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ws01.pages.workshop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class chatePagews : ContentPage
    {
        public chatePagews()
        {
            InitializeComponent();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#ED8037");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;

        }
        //private async void GetServices()
        //{
        //    HttpClient client = new HttpClient();
        //    var response = await client.GetStringAsync("http://workshopksa.com/api/xservicests");
        //    var xservicelist = JsonConvert.DeserializeObject<List<servicesusers>>(response);

        //    chat.ItemsSource = xservicelist;

        //}
    }
}