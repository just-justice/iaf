using A7mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace A7mvc.Repositories
{
    public static class UserRepository
    {
        public static List<User> Users = new List<User>
        {
            new User { Username = "Rachana", Age = 29, Donation = 1000 },
            new User { Username = "Gintoki", Age = 35, Donation = 9 },
            new User { Username = "Katsura", Age = 33, Donation = 7000 }
        };

        public static User? GetUser(string username, string password)
        {
            return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public static void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}
