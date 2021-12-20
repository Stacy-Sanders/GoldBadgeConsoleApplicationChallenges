using _01_KomodoCafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.UI
{
    public class ProgramUI
    {
        private MenuItemRepository _menuItemRepo = new MenuItemRepository();


        // Method that runs/starts the appplication
        public void Run()
        {
            SeedItemList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the manager
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Item\n" +
                    "2. View All Items\n" +
                    "3. View Items By Meal Name\n" +
                    "4. Update Existing Items\n" +
                    "5. Delete Existing Items\n" +
                    "6. Exit");

                // Get manager's input
                string input = Console.ReadLine();

                // Evaluate Manager's input and proceed as directed
                switch (input)
                {
                    case "1":
                        // Create New Item
                        CreateNewItems();
                        break;
                    case "2":
                        // View All Items
                        DisplayAllItems();
                        break;
                    case "3":
                        // View Items By Meal Name
                        DisplayAllItemsByMealName();
                        break;
                    case "4":
                        // Update Existing Items
                        UpdateExistingItems();
                        break;
                    case "5":
                        // Delete Existing Items
                        DeleteExistingItems();
                        break;
                    case "6":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create new Menu Items
        private void CreateNewItems()
        {
            Console.Clear();
            MenuItems newItem = new MenuItems();

            // MealNumber
            Console.WriteLine("Enter the meal number for the item:");
            string mealNumberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumberAsString);

            // MealName
            Console.WriteLine("Enter the meal name for the item:");
            newItem.MealName = Console.ReadLine();

            // Description
            Console.WriteLine("Enter the description for the item:");
            newItem.Description = Console.ReadLine();

            // Ingredient Type
            Console.WriteLine("Enter the Ingredient Number:\n" +
                "1. Cheese\n" +
                "2. Lettuce\n" +
                "3. Pickle\n" +
                "4. Ketchup\n" +
                "5. Mustard\n" +
                "6. Onion");

            string ingredientAsString = Console.ReadLine();
            int ingredientAsInt = int.Parse(ingredientAsString);
            newItem.TypeofIngredient = (IngredientType)ingredientAsInt;

            // Price
            Console.WriteLine("Enter the price for the item:");
            string priceAsString = Console.ReadLine();
            newItem.Price = decimal.Parse(priceAsString);

            _menuItemRepo.AddItemToList(newItem);

        }

        // View current Menu Items
        private void DisplayAllItems()
        {
            Console.Clear();

            List<MenuItems> menuItems = _menuItemRepo.GetItemsList();

            foreach (MenuItems items in menuItems)
            {
                Console.WriteLine($"Meal Number:  {items.MealNumber}\n" +
                    $"Meal Name: {items.MealName}\n" +
                    $"Description: {items.Description}");
            }
        }

        // View existing Items by Meal Name
        private void DisplayAllItemsByMealName()
        {
            Console.Clear();
            // Prompt the manager to supply a Meal Name
            Console.WriteLine("Enter the Meal Name of the items you'd like to see:");

            // Get the manager's input
            string mealName = Console.ReadLine();

            // Find the content by that title
            MenuItems items = _menuItemRepo.GetContentByMealName(mealName);

            // Display info if not null
            if (items != null)
            {
                Console.WriteLine($"Meal Name: {items.MealName}\n" +
                    $"Meal Number: {items.MealNumber}\n" +
                    $"Description: {items.Description}\n" +
                    $"Type of Ingredients: {items.TypeofIngredient}\n" +
                    $"Price: {items.Price}");
            }
            else
            {
                Console.WriteLine("No item by that Meal Name.");
            }
        }
     
        // Update Existing Items
        private void UpdateExistingItems()
        {
            // Display all items
            DisplayAllItems();

            // Ask for the Meal Name of the items to update
            Console.WriteLine("Enter the Meal Name of the items you would like to update:");

            // Get that Meal Name
            string oldMealName = Console.ReadLine();

            // Build a new object
            MenuItems newItem = new MenuItems();

            // Meal Name
            Console.WriteLine("Enter the Meal Name for the items:");
            newItem.MealName = Console.ReadLine();

            // MealNumber
            Console.WriteLine("Enter the Meal Number for the item:");
            string mealNumberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumberAsString);

            // Description
            Console.WriteLine("Enter the Description for the item:");
            newItem.Description = Console.ReadLine();

            // Ingredient Type
            Console.WriteLine("Enter the Ingredient Number:\n" +
                "1. Cheese\n" +
                "2. Lettuce\n" +
                "3. Pickle\n" +
                "4. Ketchup\n" +
                "5. Mustard\n" +
                "6. Onion");

            string ingredientAsString = Console.ReadLine();
            int ingredientAsInt = int.Parse(ingredientAsString);
            newItem.TypeofIngredient = (IngredientType)ingredientAsInt;

            // Price
            Console.WriteLine("Enter the Price for the item:");
            string priceAsString = Console.ReadLine();
            newItem.Price = decimal.Parse(priceAsString);

            // Verify the update was successful
            bool wasUpdated = _menuItemRepo.UpdateExistingItems(oldMealName, newItem);

            if (wasUpdated)
            {
                Console.WriteLine("Items successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update items.");
            }
        }

        // Delete Existing Items
        private void DeleteExistingItems()
        {
            DisplayAllItems();

            // Get the Meal Name the manager wants to remove
            Console.WriteLine("\nEnter the Meal Name you want to remove:");

            string input = Console.ReadLine();

            // Call the delete method
            bool wasDeleted = _menuItemRepo.RemoveItemFromList(input);

            // If the item was deleted - acknowledge true or false statements
            if (wasDeleted)
            {
                Console.WriteLine("The item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The item could not be deleted.");
            }
        }

        // Seed method - testing
        private void SeedItemList()
        {
            MenuItems bigBusterMeal = new MenuItems(1, "Big Buster Meal", "Two hamburger patty sandwich, large fries, large drink", IngredientType.Lettuce, 4.00m);
            MenuItems bigCluckerMeal = new MenuItems(2, "Big Clucker Meal", "Breaded chicken sandwich, large fries, large drink", IngredientType.Pickle, 4.50m);
            MenuItems bigFishMeal = new MenuItems(3, "Big Fish Meal", "Battered cod fish sandwich, large fries, large drink", IngredientType.Cheese, 3.50m);

            _menuItemRepo.AddItemToList(bigBusterMeal);
            _menuItemRepo.AddItemToList(bigCluckerMeal);
            _menuItemRepo.AddItemToList(bigFishMeal);

        }


    }
}
            
                    
                    
                    
                    
                    
            
