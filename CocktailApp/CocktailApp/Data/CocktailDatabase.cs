using CocktailApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.Data
{
    public class CocktailDatabase
    {
        public static SQLiteAsyncConnection database;

        public CocktailDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Cocktail>().Wait();
        }
        public static Task<List<Cocktail>> GetItemsAsync()
        {
            return database.Table<Cocktail>().ToListAsync();
        }

        public Task<List<Cocktail>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Cocktail>("SELECT * FROM [Cocktail] WHERE [Done] = 0");
        }

        public Task<Cocktail> GetItemAsync(int id)
        {
            return database.Table<Cocktail>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Cocktail item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Cocktail item)
        {
            return database.DeleteAsync(item);
        }
    }
}
