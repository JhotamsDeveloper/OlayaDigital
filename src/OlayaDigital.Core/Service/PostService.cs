using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Exceptions;
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

        public IEnumerable<Post> GetPosts()
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

            var _post = _unitOfWork.PostRepository.GetAll();
            return _post;
        }

        public async Task<Post> GetById(int id)
        {
            if (id == 1000)
            {
                throw new BusinessException("Esto es un prueba");
            }
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async Task InsertPost(Post post)
        {
            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.saveChangesAsync();
        }
        public async Task<bool> UpdatePost(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.saveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            await _unitOfWork.saveChangesAsync();
            return true;
        }
    }
}
