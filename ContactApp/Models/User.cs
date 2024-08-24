namespace ContactApp.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public List<Contact> Contacts { get; set; }

        public User(int userId, string firstName, string lastName, bool isAdmin)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            IsAdmin = isAdmin;
            IsActive = true;
            Contacts = new List<Contact>();
        }

        public void Deactivate()
        {
            IsActive = false;
        }
        public override string ToString()
        {
            return $"===========User===========\n" +
                $"UserId : {UserId}\n" +
                $"First Name : {FirstName}\n" +
                $"Last Name : {LastName}\n" +
                $"Is User an Admin ? : {IsAdmin}\n" +
                $"Is User Active ? : {IsActive}\n";
        }
    }
}
