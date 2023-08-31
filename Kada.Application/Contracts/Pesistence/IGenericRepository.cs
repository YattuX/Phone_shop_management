using Kada.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Contracts.Pesistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> whereExpression);
        IQueryable<T> GetQuery();
        IQueryable<T> GetQuery(string linkedElements);
        IQueryable<T> FilterQuery(IQueryable<T> query, Expression<Func<T, bool>> whereExpression);
    }
}
