using ContactApp.Exceptions;
using ContactApp.Models;

namespace ContactApp.Repository
{
    internal class AdminService
    {
        public static List<User> users = new List<User>();

        public static void CreateUser(int userId, string firstName, string lastName, bool isAdmin)
        {
            users.Add(new User(userId, firstName, lastName, isAdmin));
        }

        public static bool CheckUser(int userId)
        {
            var user = users.Find(user => user.UserId == userId && user.IsActive);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public static User ReadUser(int userId)
        {
            var user = users.Find(user => user.UserId == userId && user.IsActive);
            if (user == null)
            {
                throw new UserNotFoundException("User not found.");
            }
            return user;
        }

        public static void UpdateUser(int userId, string firstName, string lastName, bool isAdmin)
        {
            User user = ReadUser(userId);
            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                user.IsAdmin = isAdmin;
            }
        }

        public static void DeleteUser(int userId)
        {
            User user = ReadUser(userId);
            user.Deactivate();
        }
        public static List<User> GetAllUsers()
        {
            return users.Where(user => user.IsActive).ToList();
        }
    }
}

