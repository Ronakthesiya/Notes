using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWTAuthDemo.Repository
{
    public static class UserRepository
    {
        public static List<(string Username, string Password, string Role)> Users =
            new List<(string, string, string)>
            {
            ("admin", "123", "Admin"),
            ("user", "123", "User")
            };

        public static (string Username, string Role)? ValidateUser(string username, string password)
        {
            var user = Users.FirstOrDefault(x =>
                x.Username == username && x.Password == password);

            if (string.IsNullOrEmpty(user.Username))
                return null;

            return (user.Username, user.Role);
        }
    }

}