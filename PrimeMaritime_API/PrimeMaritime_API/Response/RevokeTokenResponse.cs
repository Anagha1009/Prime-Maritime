using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Response
{
    public class RevokeTokenResponse
    {
        public bool IsRevoked { get; set; }
        public string Message { get; set; }
    }
}
