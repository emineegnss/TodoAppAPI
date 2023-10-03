using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppAPI.Domain.Entities.Common;

namespace TodoAppAPI.Application.Repositories
{
    public interface IRepository<BaseEntity>
    {
        IQueryable<BaseEntity> GetAll();
        Task<bool> Remove(int id);
        Task<bool> AddAsync(BaseEntity entity);
        bool Update(BaseEntity entity);
        Task<int> SaveAsync();
        Task<BaseEntity> GetByIdAsync(int id);

    }
}
