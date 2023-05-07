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
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.IO;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;

namespace PrimeMaritime_API.Services
{
    public class CommonService : ICommonService
    {
        private readonly IConfiguration _config;
        private readonly MailSettings _mailSettings;
        public CommonService(IConfiguration config, IOptions<MailSettings> mailSettings)
        {
            _config = config;
            _mailSettings = mailSettings.Value;
        }

        public Response<int> CheckRandomNo(string RANDOM_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            int randomNo = Convert.ToInt32(DbClientFactory<CommonRepo>.Instance.CheckRandomNo(dbConn, RANDOM_NO));

            Response<int> response = new Response<int>();

            response.Succeeded = true;
            response.ResponseCode = 200;
            response.Data = randomNo;

            return response;
        }

        public Response<List<DROPDOWN>> GetDropdownData(string key, string port, string value, int value1, string value2)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<DROPDOWN>> response = new Response<List<DROPDOWN>>();

            var data = DbClientFactory<CommonRepo>.Instance.GetDropdownData(dbConn, key, port, value, value1, value2);

            if (data != null)
            {
                response.Succeeded = true;
                response.ResponseMessage = "Success";
                response.ResponseCode = 200;
                response.Data = data;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Records";
            }

            return response;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            //email.Cc.Add(MailboxAddress.Parse(mailRequest.CC));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();

            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task SendEmailBLAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            foreach (var items in mailRequest.ToEmails)
            {
                email.To.Add(MailboxAddress.Parse(items));
            }
            //email.Cc.Add(MailboxAddress.Parse(mailRequest.CC));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();

            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
