using CocktailApp.Data;
using CocktailApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EulaPage : ContentPage
    {
        public MainPage HomePage { get; set; }

        public EulaPage()
        {
            InitializeComponent();
            HomePage = new MainPage();

            BindingContext = this;
        }

        private async void Accept_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }


        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }
        
    }
}