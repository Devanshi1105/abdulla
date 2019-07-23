using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using ws01.pages.classes;

namespace ws01.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class regist : TabbedPage
    {
        public string lat;
        public string lon;
        public regist()
        {
            InitializeComponent();
            GetServices();
            activityIndicator.IsRunning = activityIndicator.IsRunning;


            Title = "انشاء حساب";

            NavigationPage.SetHasBackButton(this, false);

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#ED8037");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;

        }
     /*   public async Task xlocationAsync()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(timeout:null);
            lat = position.Latitude.ToString();
            lon = position.Longitude.ToString();
            await DisplayAlert("location!", lat + lon, "done");

        }*/

        private async Task TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            users us = new users()
            {
                username = enusername.Text,
                umobile = enuserphone.Text,
                email = enemail.Text,
                password = enpass.Text

            };

            var json = JsonConvert.SerializeObject(us);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync("http://workshopksa.com/api/xusersts", content);
            if (result.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("تنبيه!", "تم التسجيل بنجاح", "استمرار");
                await Navigation.PushModalAsync(new pages.login(enuserphone.Text));
            }
            else
            {
                await DisplayAlert("تنبيه!", "الاسم او الحساب مكرر", "موافق");
            }
        }

        private async Task TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            servicesusers su = new servicesusers
            {
                respname = enrespname.Text,
                respmobile = enrespmobile.Text,
                wsname = enshopname.Text,
                city = enshopcity.Text
            };

            var xjson = JsonConvert.SerializeObject(su);
            var xcontent = new StringContent(xjson, Encoding.UTF8, "application/json");
            HttpClient xclient = new HttpClient();
            var xresult = await xclient.PostAsync("http://workshopksa.com/api/xservicesusersts", xcontent);
            if (xresult.StatusCode == HttpStatusCode.Created)
            {
                string xmobile = enuserphone.Text;
                await DisplayAlert("تنبيه!", "تم التسجيل بنجاح", "استمرار");
                await Navigation.PushModalAsync(new pages.login(enrespmobile.Text));

            }
            else
            {
                await DisplayAlert("تنبيه!", "توجد مشكلة تأكد من الاتصال بالانترنت او تواصل مع الدعم الفني", "موافق");
            }
        }
        private async void GetServices()    
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://workshopksa.com/api/xservicests");
            var xservicelist = JsonConvert.DeserializeObject<List<xusersTs>>(response);

            serviceslist.ItemsSource = xservicelist;

        }

        private async Task serviceslist_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            

            
            
             if (e.Item == null) return;
            var selectedItem = e.Item as xusersTs;

             var xresult = await DisplayAlert("تأكيد اضافة", selectedItem.name, "اضف","الغاء");
             if (xresult)
             {
                 wsservices wss = new wsservices()
                 {
                     wsname = enshopname.Text,
                     wsservice = selectedItem.name
                 };

                 var json = JsonConvert.SerializeObject(wss);
                 var content = new StringContent(json, Encoding.UTF8, "application/json");
                 HttpClient client = new HttpClient();

                 var result = await client.PostAsync("http://workshopksa.com/api/xwsservicesTs", content);
                 if (result.StatusCode == HttpStatusCode.Created)
                 {
                     await DisplayAlert("تنبيه!", "تم الاضافة", "استمرار");
                 }
                 else
                 {
                     await DisplayAlert("تنبيه!", "توجد مشكلة تأكد من الاتصال بالانترنت او تواصل مع الدعم الفني", "موافق");
                 }
             }
             else
             {

                 await DisplayAlert("تنبيه!", "تم الالغاء", "استمرار");
             }
        }

        private void serviceslist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
         
        }
    }
}