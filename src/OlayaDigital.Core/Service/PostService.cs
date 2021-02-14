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
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<User> _userRepository;

        public PostService(IRepository<Post> postRepository,
            IRepository<User> userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
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

            var _post = await _postRepository.GetAll();
            return _post;
        }

        public async Task<Post> GetById(int id)
        {
            return await _postRepository.GetById(id);
        }

        public async Task InsertPost(Post post)
        {
            var _user = _userRepository.GetById(Convert.ToInt16(post.IdUser));

            if (_user == null)
            {
                throw new Exception("User doesn't exist");
            }
            await _postRepository.Add(post);
        }
        public async Task<bool> UpdatePost(Post post)
        {
            await _postRepository.Update(post);
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _postRepository.Delete(id);
            return true;
        }
    }
}
