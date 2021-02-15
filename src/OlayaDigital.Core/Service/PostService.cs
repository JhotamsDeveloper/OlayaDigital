using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Intarfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OlayaDigital.Core.Service
{
    public class PostService : IPostService
    {

        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            #region "De interés"
            //var _post = Enumerable.Range(1, 10).Select(x => new IdPost
            //{
            //    Id = x,
            //    Tittle = $"Tittle {x}",
            //    Url = $"Url {x}",
            //    Description = $"Description {x}",
            //    IdCategory =  x * 3,
            //    IdUser = x * 5
            //});

            //Crea una tarea que se completa después de 
            //un número específico de milisegundos.
            //await Task.Delay(10);
            #endregion

            var _post = await _unitOfWork.PostRepository.GetAll();
            return _post;
        }

        public async Task<Post> GetById(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async Task InsertPost(Post post)
        {
            var _user = _unitOfWork.PostRepository.GetById(Convert.ToInt16(post.IdUser));

            if (_user == null)
            {
                throw new Exception("User doesn't exist");
            }
            await _unitOfWork.PostRepository.Add(post);
        }
        public async Task<bool> UpdatePost(Post post)
        {
            await _unitOfWork.PostRepository.Update(post);
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;
        }
    }
}
