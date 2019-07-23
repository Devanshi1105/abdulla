using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Plugin.Media;
using System.Threading.Tasks;
using ws01.pages.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media.Abstractions;
using System.Collections.ObjectModel;

namespace ws01.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class placeorder : ContentPage
	{
        public string car, serviceneeds, usermobiles;
        ObservableCollection<MediaFile> files = new ObservableCollection<MediaFile>();


        private async void TapGestureRecognizer_Tapped_1camera(object sender, EventArgs e)
        {
           
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            files.Clear();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)

            {

                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");

                return;

            }



            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions

            {

                PhotoSize = PhotoSize.Medium,

                Directory = "Sample",

                Name = "test.jpg"

            });



            if (file == null)

                return;



            await DisplayAlert("File Location", file.Path, "OK");



            files.Add(file);
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            files.Clear();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {

                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");

                return;

            }

            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions

            {

                PhotoSize = PhotoSize.Medium

            });

            if (file == null)

                return;
            files.Add(file);
        }

        public placeorder (string serviceneed, string usermobile)
		{
			InitializeComponent ();
//            car = xcar;
            usermobiles = usermobile;
            serviceneeds = serviceneed;
           // files.CollectionChanged += Files_CollectionChanged;
        }

        private async Task TapGestureRecognizer_TappedAsync(object sender, EventArgs e)
        {
            order su = new order
            {
                userid = Convert.ToInt32(usermobiles),
               services = serviceneeds,
               carbrand = car,
               issue = enissue.Text
            };

            var xjson = JsonConvert.SerializeObject(su);
            var xcontent = new StringContent(xjson, Encoding.UTF8, "application/json");
            HttpClient xclient = new HttpClient();
            var xresult = await xclient.PostAsync("http://workshopksa.com/api/xorderts", xcontent);
            if (xresult.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("تنبيه!", "تم ارسال الطلب بنجاح - بانتظار العروض", "استمرار");
                await Navigation.PushAsync(new pages.offerlist());
            }
            else
            {
                await DisplayAlert("تنبيه!", "توجد مشكلة تأكد من الاتصال بالانترنت او تواصل مع الدعم الفني", "موافق");
            }
        }
    }
}