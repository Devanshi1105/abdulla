using Newtonsoft.Json;
//using Rg.Plugins.Popup.Extensions;
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
    public partial class login : ContentPage
    {
        public string xphone;
        public login(string xmobile)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            txtMobile.Text = xmobile;
        }
        string xcolor;
        private async Task TapGestureRecognizer_Tapped_StartAsync(object sender, EventArgs e)
        {

            users us = new users()
            {
                umobile = txtMobile.Text,
                
            };

            var json = JsonConvert.SerializeObject(us);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("http://workshopksa.com/api/xusersts/search/"+ txtMobile.Text +"");
            //await Navigation.PushPopupAsync(new loadingplus());
            string stringjson = await result.Content.ReadAsStringAsync();
            
            if (result.IsSuccessStatusCode)
            {
               // await DisplayAlert("", txtMobile.Text, "ok");
                  await Navigation.PushAsync(new myCar(txtMobile.Text));
            }
            else
            {
                await DisplayAlert("تنبيه!", "انت غير مسجل اضغط استمرار للتسجل", "استمرار");
                await Navigation.PushModalAsync(new pages.regist());
               // loadingplus.CloseAllPopup();
            }


        }




        private async Task TapGestureRecognizer_Tapped_registAsync(object sender, EventArgs e)
        {
            
           await Navigation.PushModalAsync(new pages.regist());
        }

        private void TapGestureRecognizer_Tapped_face(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_google(object sender, EventArgs e)
        {

        }

        private async Task TapGestureRecognizer_TappedAsync(object sender, EventArgs e)
        {
            
            await Navigation.PushModalAsync(new pages.workshop.ContainerWS());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }
    }
}