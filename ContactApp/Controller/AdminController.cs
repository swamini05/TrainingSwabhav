using ContactApp.Exceptions;
using ContactApp.Models;
using ContactApp.Repository;

namespace ContactApp.Controller
{
    internal class AdminController
    {
        //private AdminService _adminService;

        //public AdminController(AdminService adminService)
        //{
        //    _adminService = adminService;
        //}

        public static void AdminMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Add New User");
                Console.WriteLine("2. Update or Modify Existing User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. Display All Users");
                Console.WriteLine("5. Logout");

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
                            AddNewUser();
                            break;
                        case 2:
                            UpdateUser();
                            break;
                        case 3:
                            DeleteUser();
                            break;
                        case 4:
                            DisplayAllUsers();
                            break;
                        case 5:
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

        public static void AddNewUser()
        {
            Console.WriteLine("Enter User ID:");
            int userId = int.Parse(Console.ReadLine());
            if (AdminService.CheckUser(userId))
            {
                throw new DuplicateUserFoundException("User Already Exixts");
            }
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Is Admin (true/false):");
            bool isAdmin = bool.Parse(Console.ReadLine());

            AdminService.CreateUser(userId, firstName, lastName, isAdmin);
            Console.WriteLine("User created successfully.");
        }

        private static void UpdateUser()
        {
            Console.WriteLine("Enter User ID to Update:");
            int userId = int.Parse(Console.ReadLine());
            User user = AdminService.ReadUser(userId);

            Console.WriteLine("Enter New First Name:");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Enter New Last Name:");
            user.LastName = Console.ReadLine();
            Console.WriteLine("Is Admin (true/false):");
            user.IsAdmin = bool.Parse(Console.ReadLine());

            AdminService.UpdateUser(userId, user.FirstName, user.LastName, user.IsAdmin);
            Console.WriteLine("User updated successfully.");
        }

        public static void DeleteUser()
        {
            Console.WriteLine("Enter User ID to Delete:");
            int userId = int.Parse(Console.ReadLine());

            AdminService.DeleteUser(userId);
            Console.WriteLine("User deleted successfully.");
        }

        public static void DisplayAllUsers()
        {
            var users = AdminService.GetAllUsers();
            users.ForEach(user =>
            {
                Console.WriteLine(user);
            });
        }
    }
}
