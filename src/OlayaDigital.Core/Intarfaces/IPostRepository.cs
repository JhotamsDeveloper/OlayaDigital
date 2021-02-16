using OlayaDigital.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlayaDigital.Core.Intarfaces
{
    /*Se crea esta interfaz para generar otros métodos personalizados, 
     esta también hereda los métodos CRUD*/
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostByUser(int userId);
    }
}
