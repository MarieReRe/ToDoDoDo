using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do.Models.Identity
{
    public class UserWithToken
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
