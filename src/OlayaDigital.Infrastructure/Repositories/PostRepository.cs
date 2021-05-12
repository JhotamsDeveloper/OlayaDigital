using Microsoft.EntityFrameworkCore;
using OlayaDigital.Core.DTOs;
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
    /*Este repositorio se utiliza para crear métodos no genericos
     solamente de la entidad de POST*/
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(db_OlayaDigitalContext _contex) : base(_contex) { }

        public IEnumerable<Post> GetPostWithAudiMedia()
        {
            return _entities.Include(y => y.Medias).ToList();
        }
    }
}
