using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Core.DTOs
{
    public class MediaDto
    {
        public string FileName { get; set; }
        public int? IdPost { get; set; }
        public string Extension { get; set; }
        public float FileSize { get; set; }
        public string Route { get; set; }
        public bool Cover { get; set; }
        public virtual PostDto Post { get; set; }
    }
}
