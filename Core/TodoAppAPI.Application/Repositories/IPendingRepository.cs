using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppAPI.Domain.Entities;

namespace TodoAppAPI.Application.Repositories
{
    public interface IPendingRepository : IRepository<Pending>
    {
    }
}
