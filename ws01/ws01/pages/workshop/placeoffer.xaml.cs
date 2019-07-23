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

namespace ws01.pages.workshop
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class placeoffer : ContentPage
	{
        public string spareparts;
		public placeoffer ()
		{
			InitializeComponent ();
		}

        private async Task TapGestureRecognizer_TappedAsync(object sender, EventArgs e)
        {
            offer su = new offer
            {
                
            };

            var xjson = JsonConvert.SerializeObject(su);
            var xcontent = new StringContent(xjson, Encoding.UTF8, "application/json");
            HttpClient xclient = new HttpClient();
            var xresult = await xclient.PostAsync("http://workshopksa.com/api/xofferts", xcontent);
            if (xresult.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("تنبيه!", "تم ارسال العرض للعميل", "استمرار");
            }
            else
            {
                await DisplayAlert("تنبيه!", "توجد مشكلة تأكد من الاتصال بالانترنت او تواصل مع الدعم الفني", "موافق");
            }
        }

        private async Task TapGestureRecognizer_Tapped_1Async(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pages.workshop.orderslist());
        }   

        private void TapGestureRecognizer_Tapped_yes(object sender, EventArgs e)
        {
            spareparts = "يشمل قطع الغيار";
            btnyes.IsVisible = false;
            
        }
        private void TapGestureRecognizer_Tapped_no(object sender, EventArgs e)
        {
            spareparts = "لا يشمل قطع الغيار";
            btnno.IsVisible = false;

        }
    }
}