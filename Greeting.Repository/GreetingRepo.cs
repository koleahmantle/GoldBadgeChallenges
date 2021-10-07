using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Repository
{
    class GreetingRepo
    {
        // Make private repo list
        private List<PersonContent> _listOfGreetingContent = new List<PersonContent>();
        //Create
        public void AddPersonContent(PersonContent person)
        {
            _listOfGreetingContent.Add(person);
        }
        //Read
        public List<PersonContent> DisplayGreetingContent()
        {
            return _listOfGreetingContent;
        }
        //Update

        //Delete
        public bool DeletePerson(int id )
        {
            PersonContent person = GetPersonContentById(id);
            if(id == null)
            {
                return false;
            }
            int initialCount = _listOfGreetingContent.Count;
            _listOfGreetingContent.Remove(person);
            if(initialCount > _listOfGreetingContent.Count)
            {
                return true;
            }
            return false;
        }
        //Helper Method 
        public PersonContent GetPersonContentById(int id)
        {
            foreach(PersonContent person in _listOfGreetingContent)
            {
                if(person.Id == id)
                {
                    return person;
                }
            }
            return null;
        }
    }
}
