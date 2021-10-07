using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Repository
{
    public enum CustomerType
    {
        Potential = 1,
        Current,
        Past
    }
    public class PersonContent
    {
        //Make Person Object, properties: First Name, Last Name, Person Type
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }
        public int Id { get; set; }
        //Make constructures 
        PersonContent() { }
        PersonContent(string firstName, string lastName, CustomerType type, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
            Id = id;
        }
    }
}
