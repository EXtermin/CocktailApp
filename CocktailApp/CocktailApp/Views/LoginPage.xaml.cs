using CocktailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public User user { get; set; }

        public LoginPage ()
		{
			InitializeComponent ();
            user = new User()
            {
                Id = 1,
                Username = "",
                Password = "",
                Email = "bestaatniet@oof.nl"

            };
            BindingContext = this;
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (user.Username == "" || user.Password == "")
            {
                await DisplayAlert("Oops!! Validation Error", "Username and Password are required", "Re-try");
            }

            else if (user.Username == "test123" && user.Password == "123")
            {
                await Navigation.PushModalAsync(new MainPage());                   
            }
            else
            {
                await DisplayAlert("Oops!! Validation Error", "Username and Password are not valid", "Re-try");
            }
            

        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.user.Username = e.NewTextValue;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.user.Password = e.NewTextValue;
        }
    }
}