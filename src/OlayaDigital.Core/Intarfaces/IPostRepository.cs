using OlayaDigital.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlayaDigital.Core.Intarfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}
