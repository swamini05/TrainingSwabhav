namespace ContactApp.Models
{
    internal class ContactDetails
    {
        public int ContactDetailsId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public ContactDetails(int contactDetailsId, string type, string value)
        {
            ContactDetailsId = contactDetailsId;
            Type = type;
            Value = value;
        }
        public override string ToString()
        {
            return $"Contact Details ID : {ContactDetailsId}\n" +
                $"Type of Contact Info : {Type}\n" +
                $"Value : {Value}\n";
        }
    }
}
