using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testXamarin.Store;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private App _app;
        public LoginPage(App app)
        {
            _app = app;
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var a = Context.RestApi.Login(new TogglRestApi.Models.User(email.Text, password.Text)).Result;
                if (!String.IsNullOrEmpty(a.data.api_token))
                {
                    Context.UserData = a.data;
                    var navigationPageTracking = new NavigationPage(new Stopwatch());
                    navigationPageTracking.Title = "Tracking";

                    _app.MainPage = new TabbedPage
                    {
                        Children = {
                            navigationPageTracking,
                            new History(),
                            new User()
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                await DisplayAlert("Exception", "Login failed", "OK");
            }
        }

        private void email_Focused(object sender, FocusEventArgs e)
        {
            email.Text = "";
        }

        private void password_Focused(object sender, FocusEventArgs e)
        {
            password.Text = "";
        }
    }
}