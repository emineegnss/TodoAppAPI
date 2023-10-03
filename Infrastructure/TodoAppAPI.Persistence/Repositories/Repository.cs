using TodoAppAPI.Domain.Entities.Common;
using TodoAppAPI.Application.Repositories;
using TodoAppAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TodoAppAPI.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TodoAppDbContext _context;

        public Repository(TodoAppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T entity)
        {
           EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Detached;
        }

        public IQueryable<T> GetAll() => Table;

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(data => data.Id == id);
        }

        public async Task<bool> Remove(int id)
        {
            T entity = await Table.FirstOrDefaultAsync(data=>data.Id == id);
            EntityEntry<T> entityEntry = Table.Remove(entity);


            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<int> SaveAsync()=>await _context.SaveChangesAsync();

        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
