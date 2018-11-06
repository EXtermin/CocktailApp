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
        private string username;
        private string password;
        public MainPage HomePage { get; set; }

        public LoginPage ()
		{
			InitializeComponent ();
            HomePage = new MainPage();
            
            BindingContext = this;
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            var user = App.DatabaseCocktail.GetUserAsync(username, password).Result;
            if (username == "" || password == "")
            {
                await DisplayAlert("Oops!! Validation Error", "Username and Password are required", "Re-try");
            }

            else if (user != null)
            {
                if (username == user.Username && password == user.Password)
                {
                    await Navigation.PushModalAsync(HomePage);
                }
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
            this.username = e.NewTextValue;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.password = e.NewTextValue;
        }
    }
}