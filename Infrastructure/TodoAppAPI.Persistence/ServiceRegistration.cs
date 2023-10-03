using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TodoAppAPI.Application.Repositories;
using TodoAppAPI.Domain.Entities.Common;
using TodoAppAPI.Persistence.Contexts;
using TodoAppAPI.Persistence.Repositories;

namespace TodoAppAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TodoAppDbContext>(options=>options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<IDoneRepository,DoneRepository>();
            services.AddScoped<IInProgressRepository,InProgressRepository>();
            services.AddScoped<IPendingRepository,PendingRepository>();
            services.AddScoped<IRepository<BaseEntity>,Repository<BaseEntity>>();
        }
    }
}
