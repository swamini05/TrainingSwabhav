using ContactApp.Exceptions;
using ContactApp.Models;

namespace ContactApp.Repository
{
    internal class StaffService
    {
        public static User user;

        public static void CreateContact(int contactId, string firstName, string lastName)
        {
            if (!user.IsActive) return;
            user.Contacts.Add(new Contact(contactId, firstName, lastName));
        }

        public static bool CheckContact(int contactId)
        {
            if (!user.IsActive) throw new UserInactiveException("User is Inactive");
            Contact contact = user.Contacts.FirstOrDefault(contact => contact.ContactId == contactId && contact.IsActive);
            if (contact == null) return false;
            return true;
        }

        public static Contact ReadContact(int contactId)
        {
            if (!user.IsActive) return null;
            Contact contact = user.Contacts.FirstOrDefault(contact => contact.ContactId == contactId && contact.IsActive);
            if (contact == null)
            {
                throw new UserNotFoundException("Contact does not exist");
            }
            else if (!contact.IsActive)
            {
                throw new UserInactiveException("Contact is not active");
            }
            return contact;
        }

        public static void UpdateContact(int contactId, string firstName, string lastName)
        {
            if (!user.IsActive) return;
            Contact contact = ReadContact(contactId);
            if (contact != null)
            {
                contact.FirstName = firstName;
                contact.LastName = lastName;
            }
        }

        public static void DeleteContact(int contactId)
        {
            if (!user.IsActive) return;
            Contact contact = ReadContact(contactId);
            if (contact != null)
            {
                user.Contacts.Remove(contact);
            }
        }

        public static void CreateContactDetails(int contactId, int contactDetailsId, string type, string value)
        {
            Contact contact = ReadContact(contactId);
            contact.ContactDetailsList.Add(new ContactDetails(contactDetailsId, type, value));
        }
        public static bool CheckContactDetails(int contactId, int contactDetailsId)
        {
            Contact contact = ReadContact(contactId);
            var contactDetails = contact.ContactDetailsList.FirstOrDefault(details => details.ContactDetailsId == contactDetailsId);
            if (contactDetails == null) throw new UserNotFoundException("Contact Details Id not found");
            return true;
        }

        public static ContactDetails ReadContactDetails(int contactId, int contactDetailsId)
        {
            Contact contact = ReadContact(contactId);
            return contact.ContactDetailsList.FirstOrDefault(details => details.ContactDetailsId == contactDetailsId);
        }

        public static void UpdateContactDetails(int contactId, int contactDetailsId, string type, string value)
        {
            ContactDetails details = ReadContactDetails(contactId, contactDetailsId);
            if (details != null)
            {
                details.Type = type;
                details.Value = value;
            }
        }

        public static void DeleteContactDetails(int contactId, int contactDetailsId)
        {
            Contact contact = ReadContact(contactId);

            ContactDetails details = ReadContactDetails(contactId, contactDetailsId);
            if (details != null)
            {
                contact.ContactDetailsList.Remove(details);
            }
        }
        public static List<Contact> GetContacts()
        {
            if (!user.IsActive) throw new UserInactiveException("User is inactive");
            return user.Contacts.Where(contact => contact.IsActive).ToList();
        }

        public static List<ContactDetails> GetContactDetails(int contactId)
        {
            Contact contact = ReadContact(contactId);
            if (!contact.IsActive)
            {
                throw new UserInactiveException("Contact is not activated");
            }
            return contact.ContactDetailsList.ToList();
        }
    }
}

