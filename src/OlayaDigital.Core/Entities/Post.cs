using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
    }
}
