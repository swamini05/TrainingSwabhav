using System.Collections.Generic;

namespace ContactAppMiniProject.Models
{
    public class Contact
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual bool IsActive { get; set; } = true;
        public virtual IList<ContactDetail> ContactDetailsList { get; set; } = new List<ContactDetail>();
        public virtual User User { get; set; }
    }
}