using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface ICommonService
    {
        Response<List<DROPDOWN>> GetDropdownData(string key,string port, string value, int value1);
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
