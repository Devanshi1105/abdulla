
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ws01.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class spsc : ContentPage
    {
        Image splashImage;

        public spsc()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "logo.png",
                WidthRequest = 1 ,
                HeightRequest = 1
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            //this.BackgroundColor = Color.FromHex("#429de3");
            this.Content = sub;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 2000);
            await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            //await splashImage.ScaleTo(150, 1000, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new login(""));


        }
    }
}