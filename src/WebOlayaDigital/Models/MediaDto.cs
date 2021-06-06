using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebOlayaDigital.Models
{
    public class MediaDto
    {
        public string NameFile { get; set; }
        public int? IdPost { get; set; }
        public string Extension { get; set; }
        public float Weight { get; set; }
        public string Route { get; set; }
        public bool MyProperty { get; set; }
    }
}
