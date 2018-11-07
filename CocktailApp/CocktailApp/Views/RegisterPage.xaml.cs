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
        private string birthday;
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

        private void Birthday_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.birthday = e.NewTextValue;
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {

            RegisterUser(this.email, this.username, this.password, this.birthday);
            await Navigation.PushModalAsync(new EulaPage());
        }

        public void RegisterUser(string Email, string Username, string Password, string birthday)
        {
            var user = new User() {
                Email = Email,
                Username = Username,
                Password = Password,
                Birthday = birthday
            };
            var databaseUser = App.DatabaseCocktail;
            databaseUser.SaveUserAsync(user);
        }
    }
}