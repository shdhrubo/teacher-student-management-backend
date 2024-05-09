using CRUD.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.API.Repositories
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
      _context = context;
      _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
      await _dbSet.AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
      _dbSet.Remove(entity);
      await _context.SaveChangesAsync();
    }
  }
}
