using Cafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class Cafe_UI
    {
        private MenuRepository _menuContent = new MenuRepository();
        public void Run()
        {
            SeedContentList();
            Menu();
        }
        public void Menu()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                //display the menu 
                Console.WriteLine("Please select a menu option: \n" +
                    "1. Add a Menu Item \n" +
                    "2. Delete a menu item \n" +
                    "3. See list of all menuu items \n" +
                    "4. Exit the program");
                //get user input
                string menuChoice = Console.ReadLine();
                //use input accordingly
                switch (menuChoice)
                {
                    case "1":
                        AddMenuItemToList();
                        break;
                    case "2":
                        DeleteItemFromList();
                        break;
                    case "3":
                       DisplayItemsOnList();
                        ContinueKey();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye! Press any key to continue");
                        Console.ReadLine();
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect input, please choose option between 1-4. Please press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void AddMenuItemToList()
        {
            bool keepAdding = true;
            while (keepAdding)
            {
                Console.Clear();
                MenuContent menu = new MenuContent();
                //meal number
                Console.WriteLine("Enter the meal number: ");
                menu.MealNumber = int.Parse(Console.ReadLine());
                //meal name
                Console.WriteLine("Enter meal name: ");
                menu.MealName = Console.ReadLine();
                //description
                Console.WriteLine("Enter the description of the meal: ");
                menu.MealDescription = Console.ReadLine();
                //List of ingredients
                Console.WriteLine("Enter the list of ingredients one item at a time and seperate them with commas: ");
                menu.ListOfIngredients = Console.ReadLine();
                //price
                Console.WriteLine("Enter the price: ");
                menu.Price = double.Parse(Console.ReadLine());
                _menuContent.AddMenuContent(menu);
                Console.WriteLine("Would you like to add another menu item? y/n");
                char userInput = char.Parse(Console.ReadLine());
                if (userInput == 'n')
                {
                    keepAdding = false;
                }
            }
        }
        public void DisplayItemsOnList()
        {
            List<MenuContent> listOfMenuContent = _menuContent.DisplayMenuContent();
            foreach (MenuContent menu in listOfMenuContent)
            {
                Console.WriteLine($"#{menu.MealNumber}: {menu.MealName}\t {menu.Price}\n" +
                    $"Description: {menu.MealDescription}\n" +
                    $"Ingredients: {menu.ListOfIngredients}\n");
            }
        }
        public void DeleteItemFromList()
        {
            DisplayItemsOnList();
            Console.WriteLine("Enter the meal number you'd like to delete.");
            int mealNumber = int.Parse(Console.ReadLine());
            bool wasDeleted = _menuContent.DeleteMenuContent(mealNumber);
            if(wasDeleted == true)
            {
                Console.WriteLine("Menu Item Removed.");
            }
            else
            {
                Console.WriteLine("Unable to remove Menu Item.");
            }
            ContinueKey();
        }
        public void ContinueKey()
        {
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
        }
        public void SeedContentList()
        {
            MenuContent menu1 = new MenuContent(1, "baked chicken", "crispy chicken nuggets", "chicken, flour, eggs, onion, garlic", 7.99);
            MenuContent menu2 = new MenuContent(2, "grilled salmon", "grilled alantic salmon", "salmon, onion, garlic, salt, pepper, lemon", 15.99);
            MenuContent menu3 = new MenuContent(3, "1/4 lb burger", "juicy burger grilled to perfection", "ground beef, pepper, salt, worcestershire sauce, onion, tomatoes, lettuce", 9.99);
            _menuContent.AddMenuContent(menu1);
            _menuContent.AddMenuContent(menu2);
            _menuContent.AddMenuContent(menu3);
        }
    }
}
