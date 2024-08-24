using ContactApp.Exceptions;
using ContactApp.Repository;

namespace ContactApp.Controller
{
    internal class StaffController
    {
        public static void StaffMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Staff Menu:");
                Console.WriteLine("1. Work on Contact");
                Console.WriteLine("2. Work on Contact Details");
                Console.WriteLine("3. Logout");

                try
                {
                    string choice = Console.ReadLine();
                    if (!int.TryParse(choice, out int selectedChoice))
                    {
                        throw new InvalidChoiceException("Invalid choice, please enter a number.");
                    }

                    switch (selectedChoice)
                    {
                        case 1:
                            WorkOnContact();
                            break;
                        case 2:
                            WorkOnContactDetails();
                            break;
                        case 3:
                            exit = true;
                            break;
                        default:
                            throw new InvalidChoiceException("Invalid choice, please try again.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void WorkOnContact()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Contact Operations:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Modify Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display Contacts");
                Console.WriteLine("5. Find Contact");
                Console.WriteLine("6. Back to Staff Menu");

                try
                {
                    string choice = Console.ReadLine();
                    if (!int.TryParse(choice, out int selectedChoice))
                    {
                        throw new InvalidChoiceException("Invalid choice, please enter a number.");
                    }

                    switch (selectedChoice)
                    {
                        case 1:
                            AddContact();
                            break;
                        case 2:
                            ModifyContact();
                            break;
                        case 3:
                            DeleteContact();
                            break;
                        case 4:
                            DisplayContacts();
                            break;
                        case 5:
                            FindContact();
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            throw new InvalidChoiceException("Invalid choice, please try again.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void AddContact()
        {
            Console.Write("Enter Contact ID: ");
            int contactId = int.Parse(Console.ReadLine());
            if (StaffService.CheckContact(contactId))
            {
                throw new DuplicateUserFoundException("ContactId Already exist");
            }

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            StaffService.CreateContact(contactId, firstName, lastName);
            Console.WriteLine("Contact added successfully.");
        }

        public static void ModifyContact()
        {
            Console.Write("Enter Contact ID: ");
            int contactId = int.Parse(Console.ReadLine());
            StaffService.ReadContact(contactId);

            Console.Write("Enter New First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter New Last Name: ");
            string lastName = Console.ReadLine();

            StaffService.UpdateContact(contactId, firstName, lastName);
            Console.WriteLine("Contact updated successfully.");
        }

        public static void DeleteContact()
        {
            Console.Write("Enter Contact ID: ");
            int contactId = int.Parse(Console.ReadLine());

            StaffService.DeleteContact(contactId);
            Console.WriteLine("Contact deleted successfully.");
        }

        public static void DisplayContacts()
        {
            var contacts = StaffService.GetContacts();
            if (contacts != null && contacts.Any())
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                throw new UserNotFoundException("No Contacts present");
            }
        }

        public static void FindContact()
        {
            Console.Write("Enter Contact ID: ");
            int contactId = int.Parse(Console.ReadLine());

            var contact = StaffService.ReadContact(contactId);
            Console.WriteLine(contact);
        }

        public static void WorkOnContactDetails()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Contact Details Operations:");
                Console.WriteLine("1. Add Contact Detail");
                Console.WriteLine("2. Modify Contact Detail");
                Console.WriteLine("3. Delete Contact Detail");
                Console.WriteLine("4. Display Contact Details");
                Console.WriteLine("5. Find Contact Detail");
                Console.WriteLine("6. Back to Staff Menu");

                try
                {
                    string choice = Console.ReadLine();
                    if (!int.TryParse(choice, out int selectedChoice))
                    {
                        throw new InvalidChoiceException("Invalid choice, please enter a number.");
                    }

                    switch (selectedChoice)
                    {
                        case 1:
                            AddContactDetail();
                            break;
                        case 2:
                            ModifyContactDetail();
                            break;
                        case 3:
                            DeleteContactDetail();
                            break;
                        case 4:
                            DisplayContactDetails();
                            break;
                        case 5:
                            FindContactDetail();
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            throw new InvalidChoiceException("Invalid choice, please try again.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public static void AddContactDetail()
        {
            Console.Write("Enter Contact ID: ");
            int contactId = int.Parse(Console.ReadLine());

            Console.Write("Enter Contact Detail ID: ");
            int contactDetailsId = int.Parse(Console.ReadLine());
            if (StaffService.ReadContactDetails(contactId, contactDetailsId) != null)
            {
                throw new DuplicateUserFoundException("ContactDetails Id already exist for the given");
            }

            Console.Write("Enter Type: ");
            string type = Console.ReadLine();

            Console.Write("Enter Value: ");
            string value = Console.ReadLine();

            StaffService.CreateContactDetails(contactId, contactDetailsId, type, value);
            Console.WriteLine("Contact detail added successfully.");
        }

        public static void ModifyContactDetail()
        {
            Console.Write("Enter Contact ID: ");
            int contactId = int.Parse(Console.ReadLine());

            Console.Write("Enter Contact Detail ID: ");
            int contactDetailsId = int.Parse(Console.ReadLine());
            StaffService.CheckContactDetails(contactId, contactDetailsId);

            Console.Write("Enter New Type: ");
            string type = Console.ReadLine();

            Console.Write("Enter New Value: ");
            string value = Console.ReadLine();

            StaffService.UpdateContactDetails(contactId, contactDetailsId, type, value);
            Console.WriteLine("Contact detail updated successfully.");
        }

        public static void DeleteContactDetail()
        {
            Console.Write("Enter Contact ID: ");
            int contactId = int.Parse(Console.ReadLine());

            Console.Write("Enter Contact Detail ID: ");
            int contactDetailsId = int.Parse(Console.ReadLine());

            StaffService.DeleteContactDetails(contactId, contactDetailsId);
        }

        public static void DisplayContactDetails()
        {
            Console.Write("Enter Contact ID: ");
            int contactId = int.Parse(Console.ReadLine());

            var details = StaffService.GetContactDetails(contactId);
            if (details != null && details.Any())
            {
                foreach (var contactDetail in details)
                {
                    Console.WriteLine(contactDetail);
                }
            }
            else
            {
                Console.WriteLine("No contact details found.");
            }
        }

        public static void FindContactDetail()
        {
            Console.Write("Enter Contact ID: ");
            int contactId = int.Parse(Console.ReadLine());

            Console.Write("Enter Contact Detail ID: ");
            int contactDetailsId = int.Parse(Console.ReadLine());

            var contactDetail = StaffService.ReadContactDetails(contactId, contactDetailsId);
            if (contactDetail == null)
            {
                throw new UserNotFoundException("Contact Details not found");
            }
            Console.WriteLine(contactDetail);
        }

    }
}

