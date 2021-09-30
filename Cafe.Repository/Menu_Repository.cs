using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository
{
    class Menu_Repository
    {
        private List<MenuContent> _listOfMenuContent = new List<MenuContent>();
        //Create
        public void AddMenuContent(MenuContent menu)
        {
            _listOfMenuContent.Add(menu);
        }
        //Read
        public List<MenuContent> DisplayMenuContent()
        {
            return _listOfMenuContent;
        }
        //Delete
        public bool DeleteMenuContent(int mealNumber)
        {
            MenuContent menu = GetMenuContentById(mealNumber);
            if (mealNumber == null)
            {
                return false;
            }
            int initialCount = _listOfMenuContent.Count;
            _listOfMenuContent.Remove(menu);
            if(initialCount > _listOfMenuContent.Count)
            {
                return true;
            }
            return false;
        }
        //HelperMethod
        public MenuContent GetMenuContentById(int mealNumber)
        {
            foreach (MenuContent menu in _listOfMenuContent)
            {
                if(menu.MealNumber == mealNumber)
                {
                    return menu;
                }
            }
            return null;
        }
    }
}
