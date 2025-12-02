using System;

namespace CA1Q1
{
    class MainMenu
    {
        static void Main(string[] args)
        {
            ContactBook book = new ContactBook();

            while (true)
            {
                Console.WriteLine("\n1. Add Contact");
                Console.WriteLine("2. Show all contacts");
                Console.WriteLine("3. Search by name");
                Console.WriteLine("4. Search by mobile");
                Console.WriteLine("5. Delete contact");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Mobile (9-digit): ");
                        string mobile = Console.ReadLine();
                        try { book.AddContact(name, mobile); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case "2":
                        book.ShowAll();
                        break;

                    case "3":
                        Console.Write("Name to search: ");
                        string sName = Console.ReadLine();
                        var c1 = book.Search(sName);
                        if (c1 != null) c1.ShowInfo();
                        else Console.WriteLine("Not found");
                        break;

                    case "4":
                        Console.Write("Mobile to search: ");
                        string mInput = Console.ReadLine();
                        if (long.TryParse(mInput, out long m))
                        {
                            var c2 = book.Search(m);
                            if (c2 != null) c2.ShowInfo();
                            else Console.WriteLine("Not found");
                        }
                        else Console.WriteLine("Invalid number");
                        break;

                    case "5":
                        Console.Write("Name to delete: ");
                        string dName = Console.ReadLine();
                        if (book.Delete(dName)) Console.WriteLine("Deleted");
                        else Console.WriteLine("Not found");
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
