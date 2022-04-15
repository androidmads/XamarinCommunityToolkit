using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCommunityToolkit
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // XCT Series Sample 1: Xamarin Community Toolkit - Featured Views
            //MainPage = new MainPage();

            // XCT Series Sample 2: Master Details Page using XCT
            //MainPage = new SideMenuPage();

            // XCT Series Sample 2: Master Details Page using XCT
            MainPage = new EffectsSamplePage();
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
