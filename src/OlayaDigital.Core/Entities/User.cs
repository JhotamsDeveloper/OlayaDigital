using OlayaDigital.Core.Enumeration;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OlayaDigital.Core.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            UserName = Name + Guid.NewGuid().ToString();
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RolType? Role { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
