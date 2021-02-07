using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OlayaDigital.Core.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comentario = new HashSet<Comentario>();
            Publicacion = new HashSet<Publicacion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Publicacion> Publicacion { get; set; }
    }
}
