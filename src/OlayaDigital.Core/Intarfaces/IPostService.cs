﻿using OlayaDigital.Core.Entities;
using OlayaDigital.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlayaDigital.Core.Intarfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts(PostQueryFilter filters);
        Task<Post> GetById(int id);
        Task InsertPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);

    }
}
