using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<IQueryable<T>> GetAll();
        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> query);
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<int> SaveChanges();
        

        
    }
}
