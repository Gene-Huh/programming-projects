using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_social_networking.DAL
{
    public interface IUserListDAO
    {
        Dictionary<string, User> getUsers();
    }
}
