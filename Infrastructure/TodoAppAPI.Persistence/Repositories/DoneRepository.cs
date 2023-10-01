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
    public class DoneRepository : Repository<Done>, IDoneRepository
    {
        public DoneRepository(TodoAppDbContext context) : base(context)
        {
        }
    }
}
