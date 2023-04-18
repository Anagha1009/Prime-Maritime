using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IUserService
    {
        public Response<List<USERLIST>> GetUserList();
        public Response<string> InsertUser(USERLIST User);
        public Response<string> UpdateUser(USERLIST User);
        public Response<string> ValidateUsercode(string usercode);
        public Response<USERLIST> GetUser(string usercode);
        public Response<string> DeleteUser(string usercode);
    }
}
