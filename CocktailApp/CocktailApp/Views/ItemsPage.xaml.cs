using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CocktailApp.Data;
using CocktailApp.Models;
using CocktailApp.Views;
using CocktailApp.ViewModels;

namespace CocktailApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        private string search;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Cocktail;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void Search_Completed()
        {
            if(search != "")
            {
                viewModel.ExecuteLoadItemsCommand(search);
            }
            else
            {
                viewModel.LoadItemsCommand.Execute(App.DatabaseCocktail.GetCocktailsAsync());
            }
        }

        private void Searchbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.search = e.NewTextValue;
            Search_Completed();
        }
    }
}