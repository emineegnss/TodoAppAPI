using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppAPI.Application.Repositories;
using TodoAppAPI.Domain.Entities;
using TodoAppAPI.Persistence.Contexts;

namespace TodoAppAPI.Persistence.Repositories
{
    public class PendingRepository : Repository<Pending>, IPendingRepository
    {
        public PendingRepository(TodoAppDbContext context) : base(context)
        {
        }
    }
}
