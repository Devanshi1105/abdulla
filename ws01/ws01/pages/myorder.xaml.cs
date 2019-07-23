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
    public partial class myorder : ContentPage
    {
        string mobileno;
        public myorder(string mobno)
        {
            InitializeComponent();
            mobileno = mobno;

            GetServices();
        }
        private async void GetServices()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://workshopksa.com/api/xofferts");
            var xservicelist = JsonConvert.DeserializeObject<List<xusersTs>>(response);

            xlist.ItemsSource = xservicelist;

        }

        private void Xlist_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}