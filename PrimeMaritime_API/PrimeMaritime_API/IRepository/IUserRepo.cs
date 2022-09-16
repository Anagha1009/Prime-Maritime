using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IRepository
{
    interface IUserRepo
    {
        USER GetUserByUsername(string connstring, string username);
        USER ValidateUser(string connstring, string username, string password);
    }
}
