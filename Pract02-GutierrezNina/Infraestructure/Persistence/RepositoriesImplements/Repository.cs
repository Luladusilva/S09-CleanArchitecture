namespace Pract02_GutierrezNina.Repositories.Implements;

using Microsoft.EntityFrameworkCore;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

public class Repository<TEntity> : IRepository<TEntity>
where TEntity : class
{
    protected readonly StoreLinQDB _context;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(StoreLinQDB context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public IQueryable<TEntity> Query() => _dbSet;

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task InsertAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Insert(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}

