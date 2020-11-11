using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdultsWebAPI.Models;

namespace AdultsWebAPI.Data
{
      public class InMemoryUserService : IUserService
    {
        private ICollection<User> users;

        public InMemoryUserService()
        {
            users = new List<User>();
            users.Add(new User
            {
                Username = "Lenka",
                Password = "password"
            });
            users.Add(new User
            {
                Username = "Lucia",
                Password = "pass"
            });
        }

        public async Task<User> ValidateUser(string userName, string passWord)
        {
            User user = users.FirstOrDefault(u => u.Username.Equals(userName) && u.Password.Equals(passWord));
            if (user != null)
            {
                return user;
            }
            throw new Exception("User not found");
        }
    }
}