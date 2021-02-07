using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OlayaDigital.Core.Entities
{
    public partial class Publicacion
    {
        public Publicacion()
        {
            Auditoria = new HashSet<Auditoria>();
            Comentario = new HashSet<Comentario>();
            Multimedia = new HashSet<Multimedia>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Auditoria> Auditoria { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Multimedia> Multimedia { get; set; }
    }
}
