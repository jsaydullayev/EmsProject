using Microsoft.EntityFrameworkCore.Storage;

namespace EMS.Data.Repositories.Contracts;
//T => user
public interface IBaseRepository<T>  where T : class
{
    Task<IQueryable<T>> GetAll();
    Task<T?> GetById<TK>(TK id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task SaveChanges();
    IDbContextTransaction BeginTransaction();
}