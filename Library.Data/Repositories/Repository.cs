using System.Linq.Expressions;
using Library.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
  private readonly IDbContextFactory<LibraryDbContext> _dbFactory;

  public Repository(IDbContextFactory<LibraryDbContext> dbFactory)
  {
    _dbFactory = dbFactory;
  }

  public async Task<IEnumerable<T>> GetAllAsync()
  {
    using var context = _dbFactory.CreateDbContext();
    return await context.Set<T>().ToListAsync();
  }

  public async Task<T?> GetByIdAsync(string id)
  {
    using var context = _dbFactory.CreateDbContext();
    return await context.Set<T>().FindAsync(id);
  }

  public async Task AddAsync(T entity)
  {
    using var context = _dbFactory.CreateDbContext();
    await context.Set<T>().AddAsync(entity);
    await context.SaveChangesAsync();
  }

  public async Task UpdateAsync(T entity)
  {
    using var context = _dbFactory.CreateDbContext();
    context.Set<T>().Update(entity);
    await context.SaveChangesAsync();
  }

  public async Task DeleteAsync(string id)
  {
    using var context = _dbFactory.CreateDbContext();
    var entity = await GetByIdAsync(id);
    if (entity != null)
    {
      context.Set<T>().Remove(entity);
      await context.SaveChangesAsync();
    }
  }

  public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate)
  {
    using var context = _dbFactory.CreateDbContext();
    return await context.Set<T>().Where(predicate).ToListAsync();
  }
}