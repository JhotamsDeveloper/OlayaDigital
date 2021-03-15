using OlayaDigital.Core.CustomEntities;
using OlayaDigital.Core.Entities;
using System.Threading.Tasks;

namespace OlayaDigital.Core.Service
{
    public interface IUserSecurityService
    {
        Task RegisterUser(User userSecurity);
        Task<User> GetLoginByCredentials(UserLogin userLogin);
    }
}