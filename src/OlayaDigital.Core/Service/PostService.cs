using Microsoft.Extensions.Options;
using OlayaDigital.Core.CustomEntities;
using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Intarfaces;
using OlayaDigital.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace OlayaDigital.Core.Service
{
    public class PostService : IPostService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public PostService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PageList<Post> GetPosts(PostQueryFilter filters)
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

            //Si pageNumber == 0 Asígnele 1 de lo contratio dejelo de la misma manera 
            //filters.PageNumber = filters.PageNumber == 0 ? 1 : filters.PageNumber;


            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions
                .DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions
                .DefaultPageSize : filters.PageSize;

            var _post = _unitOfWork.PostRepository.GetAll();

            if (filters.IdUser != null)
            {
                _post = _post.Where(x => x.IdUser == filters.IdUser);
            }

            if (filters.Date != null)
            {
                //_post = _post.Where(x => x.Date.ToShortDateString() == filters.Date?.ToShortDateString());
            }

            if (filters.Description != null)
            {
                _post = _post.Where(x => x.Description.ToLower().Contains(filters.Description.ToLower()));
            }

            var pagedPosts = PageList<Post>.Create(_post, filters.PageNumber, filters.PageSize);

            return pagedPosts;
        }

        public async Task<Post> GetById(int id)
        {
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
            return true;
        }
    }
}
