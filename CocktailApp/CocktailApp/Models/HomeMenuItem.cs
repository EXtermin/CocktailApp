using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailApp.Models
{
    public enum MenuItemType
    {
        Home,
        ItemsPage,
        AboutPage,
        EulaPage,
        SettingsPage,
        LoginPage
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
