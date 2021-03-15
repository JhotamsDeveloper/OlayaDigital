using OlayaDigital.Core.CustomEntities;
using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Service;
using System.Threading.Tasks;

namespace OlayaDigital.Core.Intarfaces
{
    public class UserSecurityService : IUserSecurityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserSecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitOfWork.UserSecurityRepository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(User userSecurity)
        {
            await _unitOfWork.UserSecurityRepository.Add(userSecurity);
            await _unitOfWork.saveChangesAsync();
        }
    }
}
