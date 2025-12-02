using System;

namespace CA1Q1
{
    class Contact
    {
        private string name;
        private string mobile;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }

        public string Mobile
        {
            get { return mobile; }
            set
            {
                if (!IsValidMobile(value))
                    throw new ArgumentException("Mobile must be a 9-digit positive number");
                mobile = value;
            }
        }

        public Contact(string name, string mobile)
        {
            Name = name;
            Mobile = mobile;
        }

        private bool IsValidMobile(string number)
        {
            return long.TryParse(number, out long n) && n > 0 && number.Length == 9;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}, Mobile: {Mobile}");
        }
    }
}
