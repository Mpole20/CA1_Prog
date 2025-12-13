using System;
using System.Collections.Generic;

namespace Account
{
    public class AccService
    {
        private static List<Contact> contacts = new List<Contact>()
        {
            new Contact { FirstName="Emily", LastName="Blackwell", Company="Dublin Business School", Mobile="0871111111", Email="emily.blackwell@dbs.ie", Birthdate="1 Jan 1990" },
            new Contact { FirstName="John", LastName="Smith", Company="Microsoft", Mobile="0871111112", Email="john.smith@microsoft.com", Birthdate="15 Mar 1985" },
            new Contact { FirstName="Sarah", LastName="Jones", Company="Google Ireland", Mobile="0871111113", Email="sarah.jones@gmail.com", Birthdate="20 Apr 1992" },
            new Contact { FirstName="Michael", LastName="O'Brien", Company="Dublin City Council", Mobile="0871111114", Email="michael.obrien@dublincity.ie", Birthdate="5 May 1988" },
            new Contact { FirstName="Emma", LastName="Wilson", Company="Apple Ireland", Mobile="0871111115", Email="emma.wilson@apple.com", Birthdate="10 Jun 1995" },
            new Contact { FirstName="David", LastName="Murphy", Company="Trinity College", Mobile="0871111116", Email="david.murphy@tcd.ie", Birthdate="25 Jul 1982" },
            new Contact { FirstName="Sophie", LastName="Kelly", Company="Accenture", Mobile="0871111117", Email="sophie.kelly@accenture.com", Birthdate="30 Aug 1993" },
            new Contact { FirstName="James", LastName="Ryan", Company="Bank of Ireland", Mobile="0871111118", Email="james.ryan@boi.ie", Birthdate="12 Sep 1979" },
            new Contact { FirstName="Laura", LastName="Byrne", Company="Facebook Ireland", Mobile="0871111119", Email="laura.byrne@facebook.com", Birthdate="8 Oct 1990" },
            new Contact { FirstName="Robert", LastName="Doyle", Company="AIB", Mobile="0871111120", Email="robert.doyle@aib.ie", Birthdate="17 Nov 1984" },
            new Contact { FirstName="Grace", LastName="Fitzgerald", Company="University College Dublin", Mobile="0871111121", Email="grace.fitzgerald@ucd.ie", Birthdate="22 Dec 1996" },
            new Contact { FirstName="Thomas", LastName="McCarthy", Company="Dell Ireland", Mobile="0871111122", Email="thomas.mccarthy@dell.com", Birthdate="3 Jan 1987" },
            new Contact { FirstName="Chloe", LastName="Gallagher", Company="LinkedIn Ireland", Mobile="0871111123", Email="chloe.gallagher@linkedin.com", Birthdate="14 Feb 1991" },
            new Contact { FirstName="Patrick", LastName="Kennedy", Company="Twitter Ireland", Mobile="0871111124", Email="patrick.kennedy@twitter.com", Birthdate="19 Mar 1986" },
            new Contact { FirstName="Olivia", LastName="Lynch", Company="Amazon Ireland", Mobile="0871111125", Email="olivia.lynch@amazon.com", Birthdate="7 Apr 1994" },
            new Contact { FirstName="Daniel", LastName="Walsh", Company="Intel Ireland", Mobile="0871111126", Email="daniel.walsh@intel.com", Birthdate="28 May 1981" },
            new Contact { FirstName="Megan", LastName="Burke", Company="Salesforce Ireland", Mobile="0871111127", Email="megan.burke@salesforce.com", Birthdate="11 Jun 1989" },
            new Contact { FirstName="Kevin", LastName="Nolan", Company="Dublin Airport Authority", Mobile="0871111128", Email="kevin.nolan@daa.ie", Birthdate="24 Jul 1983" },
            new Contact { FirstName="Rachel", LastName="Flynn", Company="IBM Ireland", Mobile="0871111129", Email="rachel.flynn@ibm.com", Birthdate="9 Aug 1997" },
            new Contact { FirstName="Brian", LastName="Murray", Company="HSE Ireland", Mobile="0871111130", Email="brian.murray@hse.ie", Birthdate="16 Sep 1980" }
        };
        private static bool IsValidPhone(string phone)
        {
            string cleanPhone = phone.Replace(" ", "").Replace("-", "").Replace("+", "");
    
            return cleanPhone.Length == 9 && long.TryParse(cleanPhone, out _);
        }

        private static bool IsValidBirthdate(string birthdate)
        {
            return DateTime.TryParse(birthdate, out _);
        }

        public static void CreateNewAccount()
        {
            Console.WriteLine("\n=== CREATE NEW ACCOUNT ===");
            var contact = new Contact();
            Console.Write("First Name: "); 
            contact.FirstName = Console.ReadLine();
            Console.Write("Last Name: "); 
            contact.LastName = Console.ReadLine();
            Console.Write("Company: "); 
            contact.Company = Console.ReadLine();

        while (true)
        {
            Console.Write("Mobile (digits only, min 9): ");
            contact.Mobile = Console.ReadLine();
        
            if (IsValidPhone(contact.Mobile))
            break;
            
            Console.WriteLine("Invalid phone! Use only digits (e.g., 0871111111).");
        }
    
            Console.Write("Email: "); 
            contact.Email = Console.ReadLine();
        while (true)
        {
            Console.Write("Birthdate (e.g., 1 Jan 1990): ");
            contact.Birthdate = Console.ReadLine();
        
        if (IsValidBirthdate(contact.Birthdate))
            break;
            
            Console.WriteLine("Invalid date! Try formats like '1 Jan 1990' or '01/01/1990'.");
        }
    
            contacts.Add(contact);
            Console.WriteLine($"\nAdded: {contact.FullName}\n");
        }
        public static void ShowAllContacts()
        {
            Console.WriteLine("\n=== ALL CONTACTS ===");
            
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.FullName}");
                Console.WriteLine($"  Company: {contact.Company}");
                Console.WriteLine($"  Mobile: {contact.Mobile}");
                Console.WriteLine($"  Email: {contact.Email}");
                Console.WriteLine($"  Birthdate: {contact.Birthdate}\n");
            }
        }
       public static void ShowContact()
        {
            Console.WriteLine("\n=== VIEW CONTACT ===");
            Console.Write("Search name: ");
            string searchName = Console.ReadLine();
    
            var foundContacts = new List<Contact>();
            foreach (var contact in contacts)
            {
                if (contact.FirstName.Contains(searchName, StringComparison.OrdinalIgnoreCase) || 
                    contact.LastName.Contains(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    foundContacts.Add(contact);
                }
            }
            if (foundContacts.Count > 0)
            {
                Console.WriteLine("\n--- Found Contact(s) ---");
                foreach (var contact in foundContacts)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Company: {contact.Company}");
                    Console.WriteLine($"Mobile: {contact.Mobile}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Birthdate: {contact.Birthdate}");
                    Console.WriteLine("---------------------");
                }
            }
            else
            {
                Console.WriteLine($"No contact found with name containing '{searchName}'");
            }
        }
        public static void UpdateContact()
        {
            Console.Write("\nSearch: ");
            string name = Console.ReadLine();
            
            Contact contact = null;
            foreach (var c in contacts)
                if (c.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) || c.LastName.Contains(name, StringComparison.OrdinalIgnoreCase))
                    { contact = c; break; }

            if (contact == null) { Console.WriteLine("Contact not found."); return; }

            Console.WriteLine($"\nUpdate {contact.FullName} (Enter to skip):");
            
            Console.Write($"First [{contact.FirstName}]: ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.FirstName = input;

            Console.Write($"Last [{contact.LastName}]: ");
            if (!string.IsNullOrWhiteSpace(input = Console.ReadLine())) contact.LastName = input;

            Console.Write($"Company [{contact.Company}]: ");
            if (!string.IsNullOrWhiteSpace(input = Console.ReadLine())) contact.Company = input;

            Console.Write($"Mobile [{contact.Mobile}]: ");
            if (!string.IsNullOrWhiteSpace(input = Console.ReadLine()) && IsValidPhone(input)) 
                contact.Mobile = input;

            Console.Write($"Email [{contact.Email}]: ");
            if (!string.IsNullOrWhiteSpace(input = Console.ReadLine())) contact.Email = input;

            Console.Write($"Birthdate [{contact.Birthdate}]: ");
            if (!string.IsNullOrWhiteSpace(input = Console.ReadLine()) && IsValidBirthdate(input)) 
                contact.Birthdate = input;

            Console.WriteLine($"\nUpdated: {contact.FullName}");

        }
        public static void DeleteContact()
        {
            Console.Write("\nDelete name: ");
            string name = Console.ReadLine();
            
            Contact contact = null;
            foreach (var c in contacts)
                if (c.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) || 
                    c.LastName.Contains(name, StringComparison.OrdinalIgnoreCase))
                    { contact = c; break; }
            
            if (contact == null) { Console.WriteLine("Not found."); return; }
            
            Console.Write($"Delete {contact.FullName}? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                contacts.Remove(contact);
                Console.WriteLine($"Deleted: {contact.FullName}");
            }
        }
    }
}