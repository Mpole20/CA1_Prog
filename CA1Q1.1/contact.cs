namespace Account
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        
        public string FullName => $"{FirstName} {LastName}";
    }
}