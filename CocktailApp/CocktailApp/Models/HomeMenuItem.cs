using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailApp.Models
{
    public enum MenuItemType
    {
        Home,
        SettingsPage,
        AboutPage,
        EulaPage
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
