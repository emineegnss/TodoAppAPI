using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppAPI.Domain.Entities.Common;

namespace TodoAppAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<bool> Remove(int id);
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        Task<int> SaveAsync();

    }
}
