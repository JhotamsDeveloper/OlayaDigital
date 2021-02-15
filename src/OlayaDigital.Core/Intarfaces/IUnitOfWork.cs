using OlayaDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OlayaDigital.Core.Intarfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Post> PostRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Media> MediaRepository { get; }
        IRepository<Comment> CommentRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<Audit> AuditRepository { get; }

        void saveChanges();
        Task saveChangesAsync();
    }
}
