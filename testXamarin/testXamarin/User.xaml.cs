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
	public partial class User : ContentPage
	{
        private App _app;
		public User (App app)
		{
            _app = app;
            Context.UpdateUserPresentationData();
            this.Appearing += (o, e) => { Context.UpdateUserPresentationData(); };
            InitializeComponent ();
            BindingContext = Context.UserPresentationData;
		}

        private void updateBtn_Clicked(object sender, EventArgs e)
        {
            Context.UpdateUserDataToServer();
        }

        private void LogoutBtn_Clicked(object sender, EventArgs e)
        {
            Context.Logout();
            _app.MainPage = new TabbedPage
            {
                Children = {
                    new LoginPage(_app),
                    new Registration(_app)
                },
            };
        }
    }
}