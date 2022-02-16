using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{

    public class BaseRepository<T> : IBaseRepository<T> where T : Entity<int>, new() 
    {
        protected readonly imdbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(imdbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();    
        }

        public virtual async Task<IQueryable<T>> GetAll() => await Task.FromResult(_dbSet.AsQueryable().Where(x => x.Active == true));
        public virtual async Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> query) => await Task.FromResult(_dbSet.Where(query).AsQueryable().Where(x => x.Active == true));
        public virtual async Task<T> GetById(int id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Active == true);
        public virtual async Task<int> SaveChanges() => await _context.SaveChangesAsync();

        public virtual async Task Update (T entity)
        {
            _context.Update(entity);
           await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            entity.Active = false;
            await _context.SaveChangesAsync();
        }

        public virtual async Task Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

    }
}
