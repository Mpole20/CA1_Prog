using System;
using System.Collections.Generic;

namespace CA1Q1
{
    class ContactBook
    {
        private List<Contact> contacts = new List<Contact>();

        public ContactBook()
        {
            for (int i = 1; i <= 20; i++)
                contacts.Add(new Contact($"Person{i}", (100000000 + i).ToString()));
        }

        public void AddContact(string name, string mobile)
        {
            contacts.Add(new Contact(name, mobile));
            Console.WriteLine("Contact added!");
        }

        public void ShowAll()
        {
            foreach (var c in contacts)
                c.ShowInfo();
        }

        public Contact Search(string name)
        {
            return contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Contact Search(long mobile)
        {
            return contacts.Find(c => long.Parse(c.Mobile) == mobile);
        }

        public bool Delete(string name)
        {
            var c = Search(name);
            if (c != null)
            {
                contacts.Remove(c);
                return true;
            }
            return false;
        }
    }
}
