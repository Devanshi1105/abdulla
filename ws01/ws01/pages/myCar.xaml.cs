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
    public partial class myCar : ContentPage
    {
        string xmobile,xmodel,xcolor,xgear;

        private void Chngcar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new pickcar(xmobile));


        }

        private void Keepgoing_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContainerPage(xmobile));
        }

        public myCar(string mobileno)
        {
            InitializeComponent();
            xmobile = mobileno;
         

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#ED8037");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
            DisplayAlert("", xmobile, "ok");
            GetServices();

        }
     
        public async void GetServices()
        {
            users us = new users()
            {
                umobile = xmobile,
                color = xcolor
            };

            var json = JsonConvert.SerializeObject(us);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("http://workshopksa.com/api/xusersTs/search/" + xmobile + "");
            //await Navigation.PushPopupAsync(new loadingplus());
            var stringjson = await result.Content.ReadAsStringAsync();
            var temp = JsonConvert.DeserializeObject(stringjson);

            xlbl.Text = temp.ToString();

        }
    }
}