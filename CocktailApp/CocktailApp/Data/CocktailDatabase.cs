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
            DeleteAllCocktails();
            InsertCocktail();
        }

        #region cocktail
        public Task<List<Cocktail>> GetCocktailsAsync()
        {
            return database.Table<Cocktail>().ToListAsync();
        }

        public Task<List<Cocktail>> GetCocktailBySearchAsync(string search)
        {
            var param1 = $"%{search.Trim()}%";
            var param2 = $"%{search.Trim()}%";
            return database.QueryAsync<Cocktail>("SELECT * FROM [Cocktail] WHERE [Ingredients] LIKE ? OR [Name] LIKE ?", new string[2] { param1, param2 });
            //return database.QueryAsync<Cocktail>("SELECT * FROM [Cocktail] WHERE [Ingredients] LIKE ? ;" , new string[1] { param1 });
            //return database.QueryAsync<Cocktail>("SELECT * FROM [Cocktail]");
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

        public void InsertCocktail()
        {
            var cocktail1 = new Cocktail() {
                Name = "PENICILLIN COCKTAIL",
                Id = 0,
                Description = "De Penicillin cocktail combineert Schotse whiskey, citroensap, honinglikeur en gemberlikeur. De whiskey zorgt voor een rokerige smaak, de gemberlikeur zorgt voor warmte en pittigheid die perfect in balans wordt gebracht door de honinglikeur.",
                Ingredients = "Schotse whiskey, citroensap, honinglikeur en gemberlikeur.",
                Percentage = 4.5f };
            database.InsertAsync(cocktail1);
            var cocktail2 = new Cocktail() {
                Name = "AMERICANO",
                Id = 1,
                Description = "Campari, Martini Rosso en spa rood maken van dit drankje een echte bittere cocktail uit de shortdrinkklasse.",
                Ingredients = "Campari, Martini Rosso en spa rood",
                Percentage = 4.5f };
            database.InsertAsync(cocktail2);
            var cocktail3 = new Cocktail() {
                Name = "SEX ON THE BEACH",
                Id = 2,
                Description = "De Sex on the Beach cocktail is een zoete vodka cocktail met veel fruitige invloeden van onder andere Bols Peach en sinaasappelsap. Een ongecompliceerde, fruitige  cocktail voor het ultieme vakantiegevoel!",
                Ingredients = "Bols Peach, sinaasappelsap, vodka",
                Percentage = 40f };
            database.InsertAsync(cocktail3);
            var cocktail4 = new Cocktail() {
                Name = "APPLE VODKATINI",
                Id = 3,
                Description = "Een cocktail voor de liefhebber van de iets minder sterke cocktail!",
                Ingredients = "Vodka, appelsap, Sour apple likeur en suikersiroop.",
                Percentage = 500f };
            database.InsertAsync(cocktail4);
            var cocktail5 = new Cocktail() {
                Name = "BELLINI",
                Id = 4,
                Description = "De Bellini, een heerlijke cocktail met verse perzik of mango puree en Bols Peach of Mango likeur en prosecco, is geschikt voor iedere feestelijke gelegenheid.",
                Ingredients = "verse perzik of mango puree en Bols Peach of Mango likeur en prosecco,",
                Percentage = 4.5f };
            database.InsertAsync(cocktail5);
            var cocktail6 = new Cocktail() {
                Name = "BLUE HAWAII",
                Id = 5,
                Description = "Cocktail op basis van witte rum, Blue Curaçao,  kokosmelk en ananassap",
                Ingredients = "witte rum, Blue Curaçao,  kokosmelk en ananassap",
                Percentage = 4.5f };
            database.InsertAsync(cocktail6);
            var cocktail7 = new Cocktail() {
                Name = "DARK ’N STORMY",
                Id = 6,
                Description = "Dark 'n Stormy is een cocktail met bruine rum (the dark), ginger beer (the storm) en limoen (extra storm).",
                Ingredients = "bruine rum, ginger beer en limoen",
                Percentage = 4.5f };
            database.InsertAsync(cocktail7);
            var cocktail8 = new Cocktail() {
                Name = "LONG ISLAND ICED TEA",
                Id = 7,
                Description = "Een cocktail die is ontstaan in Amerika. Een smaakexplosie staat gegarandeerd met ingrediënten als gin, rum, tequila, en vodka.",
                Ingredients = "gin, rum, tequila, en vodka.",
                Percentage = 4.5f };
            database.InsertAsync(cocktail8);
            var cocktail9 = new Cocktail() {
                Name = "",
                Id = 8,
                Description = "testtest",
                Ingredients = "testest", Percentage = 4.5f };
            database.InsertAsync(cocktail9);
            var cocktail10 = new Cocktail() {
                Name = "MOJITO",
                Id = 9,
                Description = "De Mojito is een cocktail met rum, limoensap, rietsuiker, sodawater en munt vaak geserveerd met veel ijs.",
                Ingredients = "rum, limoensap, rietsuiker, sodawater en munt",
                Percentage = 4.5f };
            database.InsertAsync(cocktail10);
            var cocktail11= new Cocktail() {
                Name = "PINK LADY",
                Id = 10,
                Description = "Een eeuwenoude dames cocktail: The Pink Lady. Gin, grenadine en limoensap maken deze cocktail niet alleen zoet, maar geven het ook nog eens zijn lievige roze kleur.",
                Ingredients = "Gin, grenadine en limoensap maken",
                Percentage = 4.5f };
            database.InsertAsync(cocktail11);
            var cocktail12 = new Cocktail() {
                Name = "WOO WOO",
                Id = 11,
                Description = "Cranberry sap, Perziklikeur, Vodka en limoensap. De Woo Woo is een echte damescocktail.",
                Ingredients = "Cranberry sap, Perziklikeur, Vodka en limoensap.",
                Percentage = 4.5f };
            database.InsertAsync(cocktail12);
        }

        public void DeleteAllCocktails()
        {
            string query = "DELETE FROM Cocktail";
            database.ExecuteAsync(query);
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
