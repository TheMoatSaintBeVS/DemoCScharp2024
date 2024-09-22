using Memes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memes.Core.Interfaces
{
   public  interface IUsersRepos
    {
        int Add(User user);
        IEnumerable<User> GetAllUsers();
        User Find(string login);

    }
}
