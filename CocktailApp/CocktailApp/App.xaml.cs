using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CocktailApp.Views;
using System.IO;
using CocktailApp.Data;
using SQLite;
using CocktailApp.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CocktailApp
{
    public partial class App : Application
    {
        static CocktailDatabase databaseCocktail;

        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
        }

        public static CocktailDatabase DatabaseCocktail
        {
            get
            {
                if (databaseCocktail == null)
                {
                    databaseCocktail = new CocktailDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CocktailDatabase.db3"));
                    
                   
                }

                return databaseCocktail;
            }
        }

        protected override void OnStart()
        {
            if (databaseCocktail == null)
            {
                databaseCocktail = new CocktailDatabase(
                  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CocktailDatabase.db3"));
                //var user = new User()
                //{
                //    Username = "test123",
                //    Password = "123",
                //    Email = "Test@gmail.com",
                //    Id = 0

                //};
                //var user2 = new User()
                //{
                //    Username = "test1233",
                //    Password = "1233",
                //    Email = "Testt@gmail.com",
                //    Id = 1

                //};
                //var cocktail = new Cocktail()
                //{
                //    Name = "Vodka",
                //    Description = "I dont even know",
                //    Id = 0,
                //    Percentage = 4.5f
                //};
                //var cocktail2 = new Cocktail()
                //{
                //    Name = "Vodka met redbull",
                //    Description = "I dont even know test",
                //    Id = 1,
                //    Percentage = 4.7f
                //};
                //databaseCocktail.SaveCocktailAsync(cocktail);
                //databaseCocktail.SaveCocktailAsync(cocktail2);
                //databaseCocktail.SaveUserAsync(user);
                //databaseCocktail.SaveUserAsync(user2);
                //var temp = databaseCocktail.GetUsersAsync().Result;
                //var temp2 = databaseCocktail.GetCocktailsAsync().Result;
            }
                


            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
