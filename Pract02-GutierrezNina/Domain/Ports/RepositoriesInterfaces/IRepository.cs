namespace Pract02_GutierrezNina.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> Query();

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(int id);

    Task InsertAsync(TEntity entity);

    void Insert(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}