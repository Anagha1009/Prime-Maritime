using Microsoft.Extensions.Configuration;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Repository;
using PrimeMaritime_API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        public UserService(IConfiguration config)
        {
            _config = config;
        }

        public Response<string> DeleteUser(string usercode)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<UserRepo>.Instance.DeleteUser(dbConn, usercode);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "User Deleted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<USERLIST> GetUser(string usercode)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<USERLIST> response = new Response<USERLIST>();
            var data = DbClientFactory<UserRepo>.Instance.GetUserByUsercode(dbConn,usercode);

            if (data != null)
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                response.Data = data;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<List<USERLIST>> GetUserList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<USERLIST>> response = new Response<List<USERLIST>>();
            var data = DbClientFactory<UserRepo>.Instance.GetUserList(dbConn);

            if (data != null)
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                response.Data = data;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<string> InsertUser(USERLIST User)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<UserRepo>.Instance.InsertUser(dbConn, User);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "User Created Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<string> UpdateUser(USERLIST User)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<UserRepo>.Instance.UpdateUser(dbConn, User);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "User Updated Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<string> ValidateUsercode(string usercode)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            var data = DbClientFactory<UserRepo>.Instance.ValidateUsercode(dbConn, usercode);

            if (String.IsNullOrEmpty(data))
            {
                Response<string> response = new Response<string>();
                response.Succeeded = true;
                response.ResponseMessage = "Usercode doesnt exists.";
                response.ResponseCode = 200;

                return response;                
            }
            else
            {
                Response<string> response = new Response<string>();
                response.Succeeded = true;
                response.ResponseMessage = "Usercode already exists.";
                response.ResponseCode = 500;

                return response;
            }
        }
    }
}
