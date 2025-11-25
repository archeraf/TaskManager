using System.Linq.Expressions;

namespace TaskManager.Domain.Contracts.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> AddAsync(T entity);
        Task<T> Update(int id, T entity);
        void Delete(int id);
    }
}
