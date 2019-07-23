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
    public partial class chatPage : ContentPage
    {
        string mobileus, mobilews;
        public chatPage(string mobilephonae,string selectedws)
        {
            InitializeComponent();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#ED8037");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
            mobileus = mobilephonae;
            mobilews = selectedws;
            GetServices();
        }

        private void Btnsend_Clicked(object sender, EventArgs e)
        {
            var nowtime = DateTime.Now.ToString("h:mm:ss");
            var nowdate = DateTime.Now.ToString("dd/MM/yyyy");
            var xmsg = txtmsg.Text;
            chatTs su = new chatTs
            {
                usermobile = mobileus,
                wsmobile = mobilews,
                msg = xmsg,
                xtime = nowtime,
                xdate = nowdate
            };

            var xjson = JsonConvert.SerializeObject(su);
            var xcontent = new StringContent(xjson, Encoding.UTF8, "application/json");
            HttpClient xclient = new HttpClient();
            var xresult = await xclient.PostAsync("http://workshopksa.com/api/chatts", xcontent);
            if (xresult.StatusCode == HttpStatusCode.Created)
            {
             
            }
            else
            {
                await DisplayAlert("تنبيه!", "توجد مشكلة تأكد من الاتصال بالانترنت او تواصل مع الدعم الفني", "موافق");
            }
        }

        private void Chat_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void Chat_ItemTapped_1(object sender, ItemTappedEventArgs e)
        {

        }

        private async void GetServices()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://workshopksa.com/api/chatts/search/"+ mobilews +"/"+ mobilews +"");
            var xservicelist = JsonConvert.DeserializeObject<List<chatTs>>(response);

            chat.ItemsSource = xservicelist;

        }
    }
}