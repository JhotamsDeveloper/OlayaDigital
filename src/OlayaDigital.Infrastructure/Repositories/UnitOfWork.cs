﻿using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Intarfaces;
using OlayaDigital.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace OlayaDigital.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly db_OlayaDigitalContext _contex;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<Media> _mediaRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Audit> _audiRepository;
        private readonly IUserRepository _userSecurityRepository;

        public UnitOfWork(db_OlayaDigitalContext contex)
        {
            _contex = contex;
        }

        public IRepository<Post> PostRepository => 
            _postRepository ?? new BaseRepository<Post>(_contex);

        public IRepository<User> UserRepository =>
            _userRepository ?? new BaseRepository<User>(_contex);

        public IRepository<Media> MediaRepository => 
            _mediaRepository ?? new BaseRepository<Media>(_contex);

        public IRepository<Comment> CommentRepository =>
            _commentRepository ?? new BaseRepository<Comment>(_contex);

        public IRepository<Category> CategoryRepository =>
            _categoryRepository ?? new BaseRepository<Category>(_contex);

        public IRepository<Audit> AuditRepository =>
            _audiRepository ?? new BaseRepository<Audit>(_contex);

        public IUserRepository UserSecurityRepository =>
            _userSecurityRepository ?? new UserRepository(_contex);

        public void Dispose()
        {
            if (_contex != null)
            {
                _contex.Dispose();
            }
        }

        public void saveChanges()
        {
            _contex.SaveChanges();
        }

        public async Task saveChangesAsync()
        {
            await _contex.SaveChangesAsync();
        }
    }
}
