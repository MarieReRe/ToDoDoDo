using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do.Models.Identity
{
    public class LoginData
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
