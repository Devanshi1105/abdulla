using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ws01.pages.workshop
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContainerWS : ContentPage
	{
		public ContainerWS ()
		{
			InitializeComponent ();
            var page = new workshop.orderslist();
            MainView.Content = page.Content;
        }
        public void ClickTap1(object sender, EventArgs e)
        {

            var page = new workshop.orderslist();
            MainView.Content = page.Content;

        }

        public void ClickTap2(object sender, EventArgs e)
        {
            //var page = new chatPage();
            //MainView.Content = page.Content;

        }

        public void ClickTap3(object sender, EventArgs e)
        {
            var page = new workshop.wsSetting();
            MainView.Content = page.Content;

        }

        public void ClickTap4(object sender, EventArgs e)
        {
             //var page = new pages.myCar();
             //MainView.Content = page.Content;
        }
    }
}