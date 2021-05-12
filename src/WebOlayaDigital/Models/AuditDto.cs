using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebOlayaDigital.Models
{
    public class AuditDto
    {
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int? IdPost { get; set; }
    }
}
