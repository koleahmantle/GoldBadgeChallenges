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
        public void Run()
        {
            Menu();
        }
        //Menu
        public void Menu()
        {
            bool run = true;
            while (run == true)
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
                        break;
                    case "3":
                        break;
                    case "4":
                        Console.WriteLine("Goodbye! Press any key to continue");
                        Console.ReadLine();
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect input, pleasure choose option between 1-4. Please press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void AddMenuItemToList()
        {
            List<string> _listOfingredients = new List<string>();
            MenuContent menu = new MenuContent();
            //meal number
            Console.WriteLine("Enter the meal number: ");
            menu.MealNumber = int.Parse(Console.ReadLine());
            //meal name
            Console.WriteLine("Enter meal name: ");
            menu.MealName = Console.ReadLine();
            //description
            Console.WriteLine("Enter the description of the meal: ");
            menu.MealName = Console.ReadLine();
            //List of ingredients
            Console.WriteLine("Enter the list of ingredients one item at a time and seperate them with commas: ");
            string ingredients = Console.ReadLine();
            //price
            Console.WriteLine("Enter the price: ");
            menu.Price = double.Parse(Console.ReadLine());
        }
    }
}
