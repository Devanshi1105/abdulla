using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ws01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContainerPage : ContentPage
    {
        string mobilephonae;
        public ContainerPage(string xmobile)
        {
            InitializeComponent();
            mobilephonae = xmobile;
            var page = new pages.selectservice(mobilephonae);
            MainView.Content = page.Content;
        }
        public void ClickTap1(object sender, EventArgs e)
        {
            var page = new pages.selectservice(mobilephonae);
            MainView.Content = page.Content;
        }

        public void ClickTap2(object sender, EventArgs e)
        {
            var page = new pages.chatted(mobilephonae);
            MainView.Content = page.Content;
        }

        public void ClickTap3(object sender, EventArgs e)
        {
            var page = new pages.myorder(mobilephonae);
            MainView.Content = page.Content;
        }

        public void ClickTap4(object sender, EventArgs e)
        {
             var page = new pages.pickcar(mobilephonae);
             MainView.Content = page.Content;
        }
    }
}