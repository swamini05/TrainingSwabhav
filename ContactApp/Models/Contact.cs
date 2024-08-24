namespace ContactApp.Models
{
    internal class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public List<ContactDetails> ContactDetailsList { get; set; }

        public Contact(int contactId, string firstName, string lastName)
        {
            ContactId = contactId;
            FirstName = firstName;
            LastName = lastName;
            IsActive = true;
            ContactDetailsList = new List<ContactDetails>();
        }

        public void Deactivate()
        {
            IsActive = false;
        }
        public override string ToString()
        {
            return $"Contact ID : {ContactId}\n" +
                $"First Name : {FirstName}\n" +
                $"Last Name : {LastName}\n" +
                $"Is Contact active ? : {IsActive}\n";
        }
    }
}
