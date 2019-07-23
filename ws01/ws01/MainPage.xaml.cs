using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ws01
{
    public partial class pickcar : ContentPage
    {
        public pickcar(string usermobile)
        {
            InitializeComponent();
            var page = new pages.serviceType();
            MainView.Content = page.Content;
        }
        public void ClickTap1(object sender, EventArgs e)
        {

            var page = new pages.serviceType();
            MainView.Content = page.Content;

        }

        public void ClickTap2(object sender, EventArgs e)
        {
            //var page = new pages.chatPage();
            //MainView.Content = page.Content;

        }

        public void ClickTap3(object sender, EventArgs e)
        {
            var page = new pages.usersettingPage();
            MainView.Content = page.Content;

        }

        public void ClickTap4(object sender, EventArgs e)
        {
           // var page = new Page1();
           // MainView.Content = page.Content;
        }
    }
}
