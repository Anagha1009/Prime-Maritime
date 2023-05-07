using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class DROPDOWN
    {
        public string KEY_NAME { get; set; }
        public string CODE { get; set; }
        public string CODE_DESC { get; set; }
    }

    public class MailRequest
    {
        public string ToEmail { get; set; }
        public List<string> ToEmails { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }

    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
