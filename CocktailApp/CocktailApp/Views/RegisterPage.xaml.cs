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
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            RegisterUser("test","test","test");
            await Navigation.PushModalAsync(new LoginPage());
        }

        public void RegisterUser(string Email, string Username, string Password)
        {
            var user = new User() {
                Id = 0,
                Email = Email,
                Username = Username,
                Password = Password
            };
            UserDatabase.SaveItemAsync(user);
        }
    }
}