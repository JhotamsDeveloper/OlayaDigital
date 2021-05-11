using Microsoft.EntityFrameworkCore;
using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Intarfaces;
using OlayaDigital.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlayaDigital.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly db_OlayaDigitalContext _contex;

        //protected se utiliza para que esta propiedad sea visible por la clase
        //en este caso BaseRepository<T> y por todas las clases que las hereda.
        protected readonly DbSet<T> _entities;

        public BaseRepository(db_OlayaDigitalContext contex)
        {
            _contex = contex;
            _entities = _contex.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public IEnumerable<T> GetAllWithInclude()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            var _model = await _entities.FindAsync(id);
            return _model;
        }


        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }


        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }






    }
}
