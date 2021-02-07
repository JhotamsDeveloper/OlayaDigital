using Microsoft.EntityFrameworkCore;
using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Intarfaces;
using OlayaDigital.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlayaDigital.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly db_OlayaDigitalContext _db_OlayaDigitalContext;
        public PostRepository(db_OlayaDigitalContext db_OlayaDigitalContext)
        {
            _db_OlayaDigitalContext = db_OlayaDigitalContext;
        }
        public async Task<IEnumerable<Publicacion>> GetPosts()
        {
            //var _post = Enumerable.Range(1, 10).Select(x => new Post
            //{
            //    Id = x,
            //    Tittle = $"Titulo {x}",
            //    Url = $"Url {x}",
            //    Description = $"Descripcion {x}",
            //    IdCategoria =  x * 3,
            //    IdUsuario = x * 5
            //});

            //Crea una tarea que se completa después de 
            //un número específico de milisegundos.
            //await Task.Delay(10);

            var _post = await _db_OlayaDigitalContext.Publicacion.ToListAsync();

            return _post;
        }

    }
}
