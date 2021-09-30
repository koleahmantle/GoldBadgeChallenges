using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository
{
    public class MenuContent
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> ListOfIngredients { get; set; }
        public double Price { get; set; }
        public MenuContent() { }
        public MenuContent (int mealNumber, String mealName, string mealDescription, List<string> listOfIngredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = listOfIngredients;
            Price = price;
        }
    }
}
