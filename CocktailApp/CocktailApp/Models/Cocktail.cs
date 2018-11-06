using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailApp.Models
{
    public class Cocktail
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Percentage { get; set; }
    }
}
