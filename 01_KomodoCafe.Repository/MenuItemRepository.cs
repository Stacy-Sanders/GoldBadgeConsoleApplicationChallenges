using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    public class MenuItemRepository
    {
        private List<MenuItems> _menuItems = new List<MenuItems>();

        // Create
        public void AddItemToList(MenuItems item)
        {
            _menuItems.Add(item);
        }

        // Read
        public List<MenuItems> GetItemsList()
        {
            return _menuItems;
        }

        // Update
        public bool UpdateExistingItems(string originalName, MenuItems newItem)
        {
            // Find the item
            MenuItems oldItem = GetContentByMealName(originalName);

            // Update the item
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
            MenuItems item = GetContentByMealName(mealName);
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
        public MenuItems GetContentByMealName(string mealName)
        {
            foreach (MenuItems item in _menuItems)
            {
                if (item.MealName.ToLower() == mealName.ToLower())
                {
                    return item;
                }
            }

            return null;
        }
    }
}


