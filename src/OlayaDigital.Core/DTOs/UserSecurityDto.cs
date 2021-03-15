using OlayaDigital.Core.Enumeration;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Core.DTOs
{
    public class UserSecurityDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RolType? Role { get; set; }
    }
}
