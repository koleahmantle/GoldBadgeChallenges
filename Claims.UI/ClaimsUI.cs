using Claims.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.UI
{
    class ClaimsUI
    {
        private Queue<Claim> claimQueue = new Queue<Claim>();
        public void Run()
        {
            SeedMethod();
            Menu();
        }
        public void Menu()
        {
            bool play = true;
            while (play)
            {
                Console.Clear();
                Console.WriteLine("Select a menu option: \n" +
                    "1. See all claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit the program");
                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        DisplayClaimsList();
                        ContinueKey();
                        break;
                    case "2":
                        TakeCareOfClaim();
                        break;
                    case "3":
                        AddClaimToList();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye! Press any key to exit....");
                        Console.ReadKey();
                        play = false;
                        break;                  
                        
                }
            }
        }
        public void AddClaimToList()
        {
            bool keepAdding = true;
            while (keepAdding)
            {
                Console.Clear();
                Claim claim = new Claim();
                //ID
                Console.WriteLine("Enter claim ID.");
                claim.Id = int.Parse(Console.ReadLine());
                //Type
                bool correctInput = true;
                while (correctInput)
                {
                    Console.WriteLine("Enter claim type.\n1. Car\n2. Home\n3. Theft");
                    int type = int.Parse(Console.ReadLine());
                    switch (type)
                    {
                        case 1:
                            claim.Type = "Car";
                            correctInput = false;
                            break;
                        case 2:
                            claim.Type = "Home";
                            correctInput = false;
                            break;
                        case 3:
                            claim.Type = "Theft";
                            correctInput = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect input, please select option 1-3.");
                            break;
                    }
                }
                //Description
                Console.WriteLine("Enter claim description.");
                claim.Description = Console.ReadLine();
                //Amount
                Console.WriteLine("Enter claim amount.");
                claim.Amount = double.Parse(Console.ReadLine());
                //IncidentDate
                Console.WriteLine("Enter the date of the incident. dd/MM/yyy");
                claim.IncidentDate = Console.ReadLine();
                //ClaimDate
                Console.WriteLine("Enter the date claim was submitted. dd/MM/yyyy");
                claim.ClaimDate = Console.ReadLine();
                //Valid       
                Console.WriteLine("Is this a valid claim? y/n");
                char valid = char.Parse(Console.ReadLine());
                switch (valid)
                {
                    case 'y':
                    case 'Y':
                        claim.IsValid = true;     
                        break;
                    case 'n':
                    case 'N':
                        claim.IsValid = false;                        
                        break;
                    default:
                        Console.WriteLine("Wrong input, please enter y/n.");
                        break;
                }
                claimQueue.Enqueue(claim);
                System.Console.WriteLine("Would you like to add another claim? y/n");
                char userInput = char.Parse(System.Console.ReadLine());
                if (userInput == 'n')
                {
                    keepAdding = false;
                }
            }
        }
        public void TakeCareOfClaim()
        {
            Console.Clear();
            Claim claim = claimQueue.Peek();
            Console.WriteLine($"Claim ID: {claim.Id}\n" +
                $"Type: {claim.Type}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: ${claim.Amount}\n" +
                $"Date of Accident: {claim.IncidentDate}\n" +
                $"Date of claim: {claim.ClaimDate}\n" +
                $"Is Valid: {claim.IsValid}\n");
            Console.WriteLine("Do you want to deal with this claim right now? y/n");
            char userInput = char.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 'y':
                case 'Y':
                    claimQueue.Dequeue();
                    break;
                case 'n':
                case 'N':
                    break;
                default:
                    Console.WriteLine("Wrong input, please enter y/n.");
                    break;
            }
            ContinueKey();
        }
        public void DisplayClaimsList()
        {
            Console.WriteLine("ClaimID \t Type \t Description \t\t Amount \t DateOfAccident \t DateOfClain \t IsValid");
            foreach(Claim claim in claimQueue)
            {
                Console.WriteLine($"{claim.Id} \t\t {claim.Type} \t {claim.Description} \t ${claim.Amount} \t {claim.IncidentDate} \t {claim.ClaimDate} \t {claim.IsValid}");
            }
        }
        public void ContinueKey()
        {
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
        }
        public void SeedMethod()
        {
            Claim claim1 = new Claim(1, "Car", "crash on highway", 859.65, "12/12/2009", "12/19/2009", true);
            Claim claim2 = new Claim(2, "home", "tree fell on roof", 1500.35, "01/30/2010", "02/04/2010", false);
            Claim claim3 = new Claim(3, "theft", "all electronics stolen", 1010.52, "10/15/2011", "10/15/2011", true);
            claimQueue.Enqueue(claim1);
            claimQueue.Enqueue(claim2);
            claimQueue.Enqueue(claim3);
        }
    }
}
