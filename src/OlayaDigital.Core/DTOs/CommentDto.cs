using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Core.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? IdPost { get; set; }
        public int? IdUser { get; set; }

    }
}
