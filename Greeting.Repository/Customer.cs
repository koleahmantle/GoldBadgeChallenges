using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Repository
{
    public class Customer
    {
        //Make Person Object, properties: First Name, Last Name, Person Type
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerType { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        //Make constructures 
       public Customer() { }
       public  Customer(string firstName, string lastName, string customerType, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            CustomerType = customerType;
        }
    }
}
