using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailApp.Data;
using CocktailApp.Models;


namespace CocktailApp.Services
{
    public class MockDataStore : IDataStore<Cocktail>
    {
        List<Cocktail> Cocktails;

        public MockDataStore()
        {
            Cocktails = new List<Cocktail>();
            var mockItems = new List<Cocktail>
            {
                new Cocktail { Id = 1, Name = "First item", Description="This is an item description.", Percentage = 4.5f },
            };

            foreach (var Cocktail in mockItems)
            {
                Cocktails.Add(Cocktail);
            }
        }

        public async Task<bool> AddItemAsync(Cocktail item)
        {
            Cocktails.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Cocktail item)
        {
            var oldItem = Cocktails.Where((Cocktail arg) => arg.Id == item.Id).FirstOrDefault();
            Cocktails.Remove(oldItem);
            Cocktails.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Cocktails.Where((Cocktail arg) => arg.Id == id).FirstOrDefault();
            Cocktails.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Cocktail> GetItemAsync(int id)
        {
            return await Task.FromResult(Cocktails.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Cocktail>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Cocktails);
        }
    }
}