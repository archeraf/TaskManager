using System.Linq.Expressions;

namespace TaskManager.Domain.Contracts.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(int id, T entity);
        Task<bool> SaveChangesAsync();
        Task<bool> ExistsAsync(int id);
        Task DeleteByIdAsync(int id);
    }
}
