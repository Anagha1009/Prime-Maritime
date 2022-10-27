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
        Response<List<DROPDOWN>> GetDropdownData(string key);
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
