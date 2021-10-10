using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Repository
{
   public class GreetingRepo
    {
        // Make private repo list
        private List<Customer> _listOfGreetingContent = new List<Customer>();
        //Create
        public bool AddPersonContent(Customer person)
        {
            int initialCount = _listOfGreetingContent.Count;
            _listOfGreetingContent.Add(person);
            if(initialCount < _listOfGreetingContent.Count)
            {
                return true;
            }
            return false;
        }
        //Read
        public List<Customer> DisplayGreetingContent()
        {
            return _listOfGreetingContent;
        }
        //Update
        public bool UpdatePerson(int id, Customer newPerson)
        {
            Customer oldPerson = GetPersonContentById(id);
            if(oldPerson != null)
            {
                oldPerson.FirstName = newPerson.FirstName;
                oldPerson.LastName = newPerson.LastName;
                oldPerson.Id = newPerson.Id;
                oldPerson.CustomerType = newPerson.CustomerType;
                return true;
            }
            else
            {
                Console.WriteLine("Unable to update.");
                return false;
            }
        }
        //Delete
        public bool DeletePerson(int id )
        {
            Customer person = GetPersonContentById(id);
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
        public Customer GetPersonContentById(int id)
        {
            foreach(Customer person in _listOfGreetingContent)
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
