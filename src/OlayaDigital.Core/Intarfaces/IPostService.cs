using OlayaDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OlayaDigital.Core.Intarfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();
        Task<Post> GetById(int id);
        Task InsertPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
        IEnumerable<Post> GetPostWithAudiMedia();
    }
}
