using OlayaDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlayaDigital.Infrastructure.Repositories
{
    public class PostRepository
    {
        public IEnumerable<Post> GetPosts()
        {
            var _post = Enumerable.Range(1, 10).Select(x => new Post
            {
                Id = x,
                Tittle = $"Titulo {x}",
                Url = $"Url {x}",
                Description = $"Descripcion {x}",
                IdCategoria =  x * 3,
                IdUsuario = x * 5
            });

            return _post;
        }
    }
}
