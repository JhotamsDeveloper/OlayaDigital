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
    /*Este repositorio se utiliza para crear métodos no genericos
     solamente de la entidad de POST*/
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(db_OlayaDigitalContext _contex) : base(_contex) { }

        public async Task<IEnumerable<Post>> GetPostByUser(int userId)
        {
            //_entity es igual a _contex.post
            return await _entities.Where(x => 
            x.IdUser == userId).ToListAsync();
        }
    }
}
