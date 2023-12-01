using Microsoft.EntityFrameworkCore;
using SampleAPI.Entities;
using System.Collections.Generic;

namespace SampleAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SampleApiDbContext _DbContext;
       
        internal DbSet<T> table { get; set; }

        public GenericRepository(SampleApiDbContext sampleApiDbContext)
        {
            this._DbContext = sampleApiDbContext;
            this.table = this._DbContext.Set<T>();
               
        }
        public virtual IEnumerable<T> GetAllAsync()
        {
            return this.table.ToList().AsEnumerable<T>();
        }

        public virtual Task<T> GetOrderById(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> AddEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        
    }


    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAllAsync();
        Task<T> GetOrderById(Guid id);
        Task<bool> AddEntity(T entity);
        Task<bool> UpdateEntity(T entity);
        Task<bool> DeleteEntity(int id);

    }
}
