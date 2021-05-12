using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebOlayaDigital.Models
{
    public class CommentDto
    {
        public string Description { get; set; }
        public int? IdPost { get; set; }
        public int? IdUser { get; set; }
    }
}
