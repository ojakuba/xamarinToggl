using System;
using testXamarin.Store;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace testXamarin
{
    public partial class App : Application
    {
        public App()
        {
            Context.RestApi = new TogglRestApi.RestApi();
            InitializeComponent();

            //var navigationPageTracking = new NavigationPage(new Stopwatch());
            //navigationPageTracking.Title = "Tracking";

            //MainPage = new TabbedPage {
            //    Children = {
            //        navigationPageTracking,
            //        new History(),
            //        new User()            
            //    }                
            //};
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            MainPage = new TabbedPage
            {
                Children = {
                    new LoginPage(this),
                    new Registration(this)
                },
            };
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
