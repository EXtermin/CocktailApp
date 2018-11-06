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
            database.CreateTableAsync<User>().Wait();
// SaveCocktailAsync(item);
        }

        #region cocktail
        public Task<List<Cocktail>> GetCocktailsAsync()
        {
            return database.Table<Cocktail>().ToListAsync();
        }

        public Task<List<Cocktail>> GetCocktailIngredientAsync(string Search)
        {
            return database.QueryAsync<Cocktail>("SELECT * FROM [Cocktail] WHERE [Ingredient] = " + Search);
        }

        public Task<Cocktail> GetCocktailAsync(int id)
        {
            return database.Table<Cocktail>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveCocktailAsync(Cocktail item)
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

        public Task<int> DeleteCocktailAsync(Cocktail item)
        {
            return database.DeleteAsync(item);
        }
        #endregion
        #region User
        public Task<List<User>> GetUsersAsync()
        {
            return database.Table<User>().ToListAsync();
        }

        public Task<List<User>> GetUserNotDoneAsync()
        {
            return database.QueryAsync<User>("SELECT * FROM [User] WHERE [Done] = 0");
        }

        public Task<User> GetUserAsync(int id)
        {
            return database.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<User> GetUserAsync(string username, string password)
        {
            return database.Table<User>().Where(i => i.Username == username && i.Password == password).FirstOrDefaultAsync();
        }

        public void SaveUserAsync(User item)
        {
            if (item.Id != 0)
            {
                database.UpdateAsync(item);
            }
            else
            {
                database.InsertAsync(item);
            }
        }

        public Task<int> DeleteUserAsync(User item)
        {
            return database.DeleteAsync(item);
        }
#endregion
    }
}
