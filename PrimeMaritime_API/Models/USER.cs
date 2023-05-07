using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class USER
    {
        public int ID { get; set; }
        public string USERNAME { get; set; }
        public string USERTYPE { get; set; }
        public string USERCODE { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public int ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public string PORT { get; set; }
        public string DEPO { get; set; }
        public string COUNTRYCODE { get; set; }
        public string ORG_CODE { get; set; }
        public string STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public string UPDATED_DATE { get; set; }
        public string RESET_PASSWORD_TOKEN { get; set; }
        public DateTime RESET_PASSWORD_EXPIRY { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
    public class USERLIST
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string USERNAME { get; set; }
        public string USERTYPE { get; set; }
        public string USERCODE { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public int ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public string PORT { get; set; }
        public string DEPO { get; set; }
        public string COUNTRYCODE { get; set; }
        public string ORGANISATION { get; set; }
        public string ORG_CODE { get; set; }
        public string LOCATION { get; set; }
        public string USERADDRESS { get; set; }
        public bool STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
    }
}
