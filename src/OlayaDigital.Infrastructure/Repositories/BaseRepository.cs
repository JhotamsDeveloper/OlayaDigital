using Microsoft.EntityFrameworkCore;
using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Intarfaces;
using OlayaDigital.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OlayaDigital.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly db_OlayaDigitalContext _contex;
        private readonly DbSet<T> _entities;

        public BaseRepository(db_OlayaDigitalContext contex)
        {
            _contex = contex;
            _entities = _contex.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            _entities.Add(entity);
            await _contex.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _entities.Update(entity);
            await _contex.SaveChangesAsync();
        }


        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
            await _contex.SaveChangesAsync();
        }






    }
}
