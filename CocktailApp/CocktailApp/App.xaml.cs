using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CocktailApp.Views;
using System.IO;
using CocktailApp.Data;
using SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CocktailApp
{
    public partial class App : Application
    {
        static CocktailDatabase databaseCocktail;
        static UserDatabase databaseUser;

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
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return databaseCocktail;
            }
        }
        public static UserDatabase DatabaseUser
        {
            get
            {
                if (databaseUser == null)
                {
                    databaseUser = new UserDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return databaseUser;
            }
        }

        protected override void OnStart()
        {
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
