using Ems.Data.Contexts;
using Ems.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ems.Data.Repositories;

public class BaseRepository<T>(EMSContext context)
    : IBaseRepository<T>
    where T : class
{
    private readonly EMSContext _context = context;

    public async Task<IQueryable<T>> GetAll()
    {
        var entities = _context.Set<T>()
            .AsQueryable();

        return entities;
    }

    public async Task<T?> GetById<TK>(TK id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        return entity;
    }

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task SaveChanges() => await _context.SaveChangesAsync();
    public IDbContextTransaction BeginTransaction() => _context.Database.BeginTransaction();
}