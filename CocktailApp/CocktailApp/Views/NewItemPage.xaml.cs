using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CocktailApp.Models;

namespace CocktailApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Cocktail Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Cocktail
            {
                Id = 1,
                Name = "Cocktail name",
                Description = "This is an Cocktail description.",
                Ingredients = "Enter ingredients here",
                Percentage = 4.5f,
                //Image = GetImageFromPicker()
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}