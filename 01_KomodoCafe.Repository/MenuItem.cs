using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    public enum IngredientType
    {
        Cheese = 1,
        Lettuce,
        Pickle,
        Ketchup,
        Mustard,
        Onion
    }

    // Plain Old C# Object
    public class MenuItems
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public IngredientType TypeOfIngredient { get; set; }
        public decimal Price { get; set; }

        public MenuItems() { }

        public MenuItems(int mealNumber, string mealName, string description, IngredientType ingredient, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            TypeOfIngredient = ingredient;
            Price = price;
        }
    }
}

    


