using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CocktailApp.Data;
using CocktailApp.Models;

namespace CocktailApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private string username;
        private string password;
        private string email;
        private int age;
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.email = e.NewTextValue;
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.username = e.NewTextValue;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.password = e.NewTextValue;
        }

        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.age = Int32.Parse(e.NewTextValue);
            }
            catch (FormatException)
            {
                DisplayAlert("Oops!! Validation Error", "Please put only a number in it", "Re-try");
            }

        }

        private async void Register_Clicked(object sender, EventArgs e)
        {

            RegisterUser(this.email, this.username, this.password, this.age);
            await Navigation.PushModalAsync(new LoginPage());
        }

        public void RegisterUser(string Email, string Username, string Password, int age)
        {
            var user = new User() {
                Email = Email,
                Username = Username,
                Password = Password,
                Age = age
            };
            var databaseUser = App.DatabaseCocktail;
            databaseUser.SaveUserAsync(user);
        }
    }
}