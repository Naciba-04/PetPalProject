using Microsoft.EntityFrameworkCore;
using Project.Core.Model.Common;
using Project.DAL.Contexts;
using Project.DAL.Repository.Abstaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repository.Implementation;

public class GenericRepository<T>(PetPatFinalProjectDbContext _context) : IGenericRepository<T> where T : BaseEntity, new()
{
    public DbSet<T> Table => _context.Set<T>();

    public async Task CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        Table.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<T>> GetAllAsync(params string[] includes)
    {
        IQueryable<T> query = Table;
        if (includes.Length > 0)
        {
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
        }
        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id, params string[] includes)
    {
        IQueryable<T> query = Table;
        if (includes.Length > 0)
        {
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
        }
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        Table.Update(entity);
        await _context.SaveChangesAsync();
    }
}
