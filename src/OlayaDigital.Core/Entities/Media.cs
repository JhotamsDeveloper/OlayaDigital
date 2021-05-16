using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OlayaDigital.Core.Entities
{
    public partial class Media : BaseEntity
    {
        public string FileName { get; set; }
        public int? IdPost { get; set; }
        public string Extension { get; set; }
        public float FileSize { get; set; }
        public string Route { get; set; }
        public bool Cover { get; set; }
        public virtual Post Post { get; set; }
    }
}
