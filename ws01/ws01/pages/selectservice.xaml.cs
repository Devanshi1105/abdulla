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
    public partial class selectservice : ContentPage
    {
        public string xmobile;
        public string xservice;
        public selectservice(string serviceneed)
        {
            xmobile = serviceneed;
            InitializeComponent ();
            Title = "نوع الخدمة";
            xservice = serviceneed;
            GetServices();
            //activityIndicator.IsRunning = activityIndicator.IsRunning;
            
            NavigationPage.SetHasBackButton(this, false);
            //ListfillAsync();
           
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#ED8037");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }
        
        private async void GetServices()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://workshopksa.com/api/xservicests");
            var xservicelist = JsonConvert.DeserializeObject<List<xusersTs>>(response);

            serviceslist.ItemsSource = xservicelist;

        }

        private void Serviceslist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
     }

        private void Serviceslist_ItemTapped_1(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as xusersTs;
            DisplayAlert("اخترت", selectedItem.name, "موافق");
            if (App.Current.MainPage is NavigationPage)
                (App.Current.MainPage as NavigationPage).PushAsync(new placeorder(selectedItem.ToString(),xmobile));

        }
    }
}