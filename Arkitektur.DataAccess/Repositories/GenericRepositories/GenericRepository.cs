using Arkitektur.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.DataAccess.Repositories.GenericRepositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext Context;
    private readonly DbSet<TEntity> _table;

    public GenericRepository(AppDbContext context)
    {
        Context = context;
        _table = context.Set<TEntity>();
    }
    public async Task CreateAsync(TEntity entity)
    {
     
        await Context.AddAsync(entity);
    }
    public void Delete(TEntity entity)
    {
        Context.Remove(entity);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _table.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _table.FindAsync(id);
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return _table;
    }

    public void Update(TEntity entity)
    {
        Context.Update(entity);
    }
}