using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpSchoolECommerce.IdentityServer.DTOs
{
    public class SignUpDTOs
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
