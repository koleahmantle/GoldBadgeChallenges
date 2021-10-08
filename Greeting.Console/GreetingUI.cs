using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greeting.Repository;

namespace Greeting.UI
{
   public class GreetingUI //Why do I need system here
    {
        private GreetingRepo _personContent = new GreetingRepo();
        public void Run()
        {
            Menu();
        }
        public void Menu()
        {
            bool play = true;
            while (play)
            {
                System.Console.Clear();
                //Display the menu
                System.Console.WriteLine("Please select a menu option: \n" +
                    "1. Add a Customer \n" +
                    "2. Delete a Customer\n" +
                    "3. Update a Customer\n" +
                    "4. See list of all Customers\n" +
                    "5. Exit the program");
                //Get user input
                string menuChoice = System.Console.ReadLine();
                //user input switch
                switch (menuChoice)
                {
                    case "1":
                        AddCustomerToList();
                        break;
                    case "2":
                        DeleteCustomerFromList();
                        break;
                    case "3":
                        UpdateCustomerInList();
                        break;
                    case "4":
                        DisplayCustomerList();
                        ContinueKey();
                        break;
                    case "5":
                        System.Console.WriteLine("Goodbye! Press any key to continue...");
                        System.Console.ReadKey();
                        play = false;
                        break;
                    default:
                        System.Console.WriteLine("Incorrect input, please choose option between 1-4. Please any key to continue...");
                        System.Console.ReadKey();
                        break;
                }
            }
        }
        public void AddCustomerToList()
        {
            bool keepAdding = true;
            while (keepAdding)
            {
                System.Console.Clear();
                Customer person = new Customer();
                //First Name
                System.Console.WriteLine("Please enter the customer's first name.");
                person.FirstName = System.Console.ReadLine();
                //Last Name
                System.Console.WriteLine("Please enter the customer's last name.");
                person.LastName = System.Console.ReadLine();
                //ID
                System.Console.WriteLine("Please enter the customer's ID.");
                person.Id = int.Parse(System.Console.ReadLine());
                //Type
                System.Console.WriteLine("Please enter the customer type.\n 1. Potential\n 2.Current\n 3.Past");
                person.CustomerType = System.Console.ReadLine();
                switch (person.CustomerType)
                {
                    case "1":
                        person.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                        break;
                    case "2":
                      person.Email = "It's been a long time since we've heard from you, we want you back.";
                        break;
                    case "3":
                       person.Email = "We currently have the lowest rates on Helicopter Insurance!";
                        break;
                    default:
                        System.Console.WriteLine("Incorrect input, please select option 1-3.");
                        break;
                }
                _personContent.AddPersonContent(person);
                System.Console.WriteLine("Would you like to add another menu item? y/n");
                char userInput = char.Parse(System.Console.ReadLine());
                if (userInput == 'n')
                {
                    keepAdding = false;
                }
            }
        }
        public void DeleteCustomerFromList()
        {
            DisplayCustomerList();
            System.Console.WriteLine("Enter the customer ID you'd like to delete.");
            int id = int.Parse(System.Console.ReadLine());
            bool wasDeleted = _personContent.DeletePerson(id);
            if (wasDeleted == true)
            {
                System.Console.WriteLine("Customer Removed.");
            }
            else
            {
                System.Console.WriteLine("Unable to remove Customer.");
            }
            ContinueKey();
        }
        public void UpdateCustomerInList()
        {
            System.Console.Clear();
            DisplayCustomerList();
            System.Console.WriteLine("Enter the ID of the customer you'd like to update.");
            int id =int.Parse(System.Console.ReadLine());
            Customer person = new Customer();
            //First Name
            System.Console.WriteLine("Please enter the customer's first name.");
            person.FirstName = System.Console.ReadLine();
            //Last Name
            System.Console.WriteLine("Please enter the customer's last name.");
            person.LastName = System.Console.ReadLine();
            //ID
            System.Console.WriteLine("Please enter the customer's ID.");
            person.Id = int.Parse(System.Console.ReadLine());
            //Type
            System.Console.WriteLine("Please enter the customer type.\n 1. Potential\n 2.Current\n 3.Past");
            person.CustomerType = System.Console.ReadLine();
            switch (person.CustomerType)
            {
                case "1":
                    person.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case "2":
                    person.Email = "It's been a long time since we've heard from you, we want you back.";
                    break;
                case "3":
                    person.Email = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
                default:
                    System.Console.WriteLine("Incorrect input, please select option 1-3.");
                    break;
            }
            _personContent.UpdatePerson(id, person);
        }
        public void DisplayCustomerList()
        {               
            List<Customer> listOfCustomers = _personContent.DisplayGreetingContent();
            System.Console.WriteLine("ID \t First Name \t Last Name \t Type \t Email");
            foreach(Customer person in listOfCustomers)
            {
                System.Console.WriteLine($"{person.Id}\t{person.FirstName}\t\t{person.LastName}\t{person.CustomerType}\t{person.Email}");
            }
        }
        public void ContinueKey()
        {
            System.Console.WriteLine("Press Any Key to Continue...");
            System.Console.ReadKey();
        }
    }
}
