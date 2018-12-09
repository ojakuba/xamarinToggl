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
	public partial class Registration : ContentPage
	{
        private App _app;
        public Registration (App app)
		{
            _app = app;
			InitializeComponent ();

            var tapGestureRecognizerTerms = new TapGestureRecognizer();
            tapGestureRecognizerTerms.Tapped += (s, e) => {
                Device.OpenUri(new Uri("https://toggl.com/legal/terms/"));
            };
            terms.GestureRecognizers.Add(tapGestureRecognizerTerms);

            var tapGestureRecognizerPrivacy = new TapGestureRecognizer();
            tapGestureRecognizerPrivacy.Tapped += (s, e) => {
                Device.OpenUri(new Uri("https://toggl.com/legal/privacy/"));
            };
            terms.GestureRecognizers.Add(tapGestureRecognizerPrivacy);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var emailstr = email.Text;
            var pass = password.Text;
            try
            {
                
                var a =Context.RestApi.SignUp(new TogglRestApi.Models.SignUpData(emailstr, pass)).Result;
                try
                {
                    var b = Context.RestApi.Login(new TogglRestApi.Models.User(emailstr, pass)).Result;
                    if (!String.IsNullOrEmpty(b.data.api_token))
                    {
                        var navigationPageTracking = new NavigationPage(new Stopwatch());
                        navigationPageTracking.Title = "Tracking";

                        _app.MainPage = new TabbedPage
                        {
                            Children = {
                            navigationPageTracking,
                            new History(),
                            new User(_app)
                        }
                        };
                    }
                }
                catch
                {
                    await DisplayAlert("Exception", "Registration was done, but Login failed", "OK");
                }
            }
            catch 
            {
                await DisplayAlert("Exception", "Registration failed", "OK");
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