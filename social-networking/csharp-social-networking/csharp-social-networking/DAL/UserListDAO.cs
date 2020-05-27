using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_social_networking.DAL
{
    public class UserListDAO
    {
        public Dictionary<string, User> getUsers()
        {
            Dictionary<string, User> users = new Dictionary<string, User>
            {
                {"Charlie", new User("Charlie")},
                {"Alice", new User("Alice")},
                {"Bob", new User("Bob")}
            };
            return users;
        }
    }
}
