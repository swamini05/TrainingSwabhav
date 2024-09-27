namespace ContactAppMiniProject.Models
{
    public class ContactDetail
    {
        public virtual int Id { get; set; }
        public virtual string Type { get; set; }
        public virtual string Value { get; set; }
        public virtual Contact Contact { get; set; }
    }
}