using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OlayaDigital.Core.Entities
{
    public partial class Comment : BaseEntity
    {
        public string Description { get; set; }
        public int? IdPost { get; set; }
        public int? IdUser { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
