using CocktailApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.Data
{
    public class UserDatabase
    {
        public static SQLiteAsyncConnection database;

        public UserDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
        }
        public static Task<List<User>> GetItemsAsync()
        {
            return database.Table<User>().ToListAsync();
        }

        public Task<List<User>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<User>("SELECT * FROM [User] WHERE [Done] = 0");
        }

        public Task<User> GetItemAsync(int id)
        {
            return database.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public static void SaveItemAsync(User item)
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

        public Task<int> DeleteItemAsync(User item)
        {
            return database.DeleteAsync(item);
        }
    }
}
