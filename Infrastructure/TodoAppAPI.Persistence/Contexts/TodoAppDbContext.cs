using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppAPI.Domain.Entities;

namespace TodoAppAPI.Persistence.Contexts
{
    public class TodoAppDbContext : DbContext
    {
        public TodoAppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Done> Dones { get; set; }
        public DbSet<InProgress> InProgresies { get; set; }
        public DbSet<Pending> Pendings { get; set; }



    }
}
