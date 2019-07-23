using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ws01.pages.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ws01.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class pickcar : ContentPage
	{
        public string carbrands, serviceneeds, usermobiles;
		public pickcar (string usermobile)
		{
			InitializeComponent ();

            Title = "نوع سيارتك";
            
            //carbrands = carbrand;
            //serviceneeds = serviceneed;
            usermobiles = usermobile;

            _ = GetBrand();
            _ = GetColor();
            _ = GetModel();

            NavigationPage.SetHasBackButton(this, true);

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#ED8037");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }

        private void pickbrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickbrand.SelectedIndex == -1)
            {
                //pickbrand.Color = Color.Default;
            }
            else
            {
                string colorName = pickbrand.Items[pickbrand.SelectedIndex];
                
            }
        }

        private async Task GetBrand()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://workshopksa.com/api/carbrandts");
            var xservicelist = JsonConvert.DeserializeObject<List<carBrand>>(response);

            pickbrand.ItemsSource = xservicelist;
        }
        private async Task GetColor()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://workshopksa.com/api/carcolor");
            var xservicelist = JsonConvert.DeserializeObject<List<carBrand>>(response);

            pickcolor.ItemsSource = xservicelist;
        }
        private async Task GetModel()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://workshopksa.com/api/modelyy");
            var xservicelist = JsonConvert.DeserializeObject<List<carBrand>>(response);

            pickmodel.ItemsSource = xservicelist;
        }
        private async Task TapGestureRecognizer_TappedAsync(object sender, EventArgs e)
        {
            //var pickedcar = pickbrand.SelectedItem.ToString();
            string pickedcar = pickbrand.Items[pickbrand.SelectedIndex];
            //-----------
            users us = new users()
            {
                umobile = usermobiles,
                carbrand = pickedcar,

            };

            var json = JsonConvert.SerializeObject(us);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PutAsync("http://workshopksa.com/api/xusersts/'"+usermobiles+"'", content);
            if (result.StatusCode == HttpStatusCode.Created)
            {
               
                // await Navigation.PushModalAsync(new pages.login(usermobiles));
                await Navigation.PushAsync(new pages.placeorder( serviceneeds, usermobiles));

            }
            else
            {
                await DisplayAlert("تنبيه!", "خطأ", "موافق");
            }
            //-----
        }
    }
}