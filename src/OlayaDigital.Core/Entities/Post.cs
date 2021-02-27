using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OlayaDigital.Core.Entities
{
    public partial class Post : BaseEntity
    {
        public Post()
        {
            Audits = new HashSet<Audit>();
            Coments = new HashSet<Comment>();
            Medias = new HashSet<Media>();
        }

        public string Tittle { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int? IdCategory { get; set; }
        public int? IdUser { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Audit> Audits { get; set; }
        public virtual ICollection<Comment> Coments { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
    }
}
