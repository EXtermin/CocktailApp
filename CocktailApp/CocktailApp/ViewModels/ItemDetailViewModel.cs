using System;

using CocktailApp.Models;

namespace CocktailApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Cocktail Item { get; set; }
        public ItemDetailViewModel(Cocktail item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
