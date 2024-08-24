using ContactApp.Exceptions;
using ContactApp.Models;
using ContactApp.Repository;

namespace ContactApp.Controller
{
    internal class UserLogin
    {
        public static void DoTask()
        {
            // Admin creates users
            AdminService.CreateUser(1, "Admin", "User", true);
            AdminService.CreateUser(2, "Staff", "User", false);
            Console.WriteLine("Users created.");

            try
            {
                while (true)
                {
                    Console.WriteLine("Enter User ID to Login:");
                    int userId = int.Parse(Console.ReadLine());

                    User user = AdminService.ReadUser(userId);
                    if (user == null) throw new UserNotFoundException("User not found.");
                    if (!user.IsActive) throw new UserInactiveException("User is inactive.");

                    if (user.IsAdmin)
                    {
                        AdminController.AdminMenu();
                    }
                    else
                    {
                        StaffService.user = user;
                        StaffController.StaffMenu();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
