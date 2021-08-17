using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVentas
{
    public partial class App : Application
    {
        public static string url = "https://a945482ed86d.ngrok.io/api/";//se debe cambiar
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
