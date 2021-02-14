using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Core.DTOs
{
    public class PostDto
    {
        public string Tittle { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int? IdCategory { get; set; }
        public int? IdUser { get; set; }
    }
}
