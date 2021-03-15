using OlayaDigital.Core.CustomEntities;
using OlayaDigital.Core.Entities;
using System.Threading.Tasks;

namespace OlayaDigital.Core.Intarfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetLoginByCredentials(UserLogin login);
    }
}
