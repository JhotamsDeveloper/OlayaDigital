using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Core.DTOs
{
    public class AuditDto
    {
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int? IdPost { get; set; }
    }
}
