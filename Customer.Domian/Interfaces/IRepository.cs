using Customer.Domain.Models;
using System.Linq.Expressions;


namespace Customer.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> List();
        Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task<bool> Delete(int id);
        Task<T> Edit(T entity);
    }    
}
