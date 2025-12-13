using System;

namespace Account
{
    class AccCreation
    {
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("=== ACCOUNT MANAGEMENT ===");
                Console.WriteLine("1. Create new Account");
                Console.WriteLine("2. View all Accounts");
                Console.WriteLine("3. Show contact details");
                Console.WriteLine("4. Update Contact");
                Console.WriteLine("5. Delete Contact");
                Console.WriteLine("6. Exit\n");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.\n");
                    choice = -1; 
                    continue;
                }

                switch(choice)
                {
                    case 1:
                    AccService.CreateNewAccount();
                    break;

                    case 2:
                    AccService.ShowAllContacts();
                    break;

                    case 3:
                    AccService.ShowContact();
                    break;

                    case 4:
                    AccService.UpdateContact();
                    break;

                    case 5:
                    AccService.DeleteContact();
                    break;

                    case 6:
                    Console.WriteLine("Exiting system\n");
                    break;

                    default:
                    Console.WriteLine("Invalid choice! Please enter 0-6\n");
                    break;
                }

            } while (choice != 6);
        }
    }
}