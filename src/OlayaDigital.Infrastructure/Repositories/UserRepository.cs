using Microsoft.EntityFrameworkCore;
using OlayaDigital.Core.CustomEntities;
using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Intarfaces;
using OlayaDigital.Infrastructure.Data;
using System.Threading.Tasks;

namespace OlayaDigital.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(db_OlayaDigitalContext context) : base(context){ }

        public async Task<User> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => 
                x.Name == login.Name && x.Password == login.Password);
        }
    }
}
