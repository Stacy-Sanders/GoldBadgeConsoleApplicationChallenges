using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    public class MenuItemRepository
    {
        private List<MenuItem> _menuItems = new List<MenuItem>();

        // Create
        public void AddItemToList(MenuItem item)
        {
            _menuItems.Add(item);
        }

        // Read
        public List<MenuItem> GetItemsList()
        {
            return _menuItems;
        }

        // Update
        public bool UpdateExistingItems(string originalName, MenuItem newItem)
        {
            // Find the content
            MenuItem oldItem = GetContentByMealName(originalName);

            // Update the content
            if (oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.Description = newItem.Description;
                oldItem.TypeofIngredient = newItem.TypeofIngredient;
                oldItem.Price = newItem.Price;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveItemFromList(string mealName)
        {
            MenuItem item = GetContentByMealName(mealName);
            if (item == null)
            {
                return false;
            }

            int initialCount = _menuItems.Count;
            _menuItems.Remove(item);

            if (initialCount > _menuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper Method
        public MenuItem GetContentByMealName(string mealName)
        {
            foreach (MenuItem item in _menuItems)
            {
                if (item.MealName == mealName)
                {
                    return item;
                }
            }

            return null;
        }
    }
}


