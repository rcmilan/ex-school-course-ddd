using Abroad.Domain.Entities;
using Abroad.Domain.Repositories;
using Abroad.Infrastructure.Context;
using Abroad.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Abroad.Infrastructure
{
    public static class ModuleDependency
    {
        public static void AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddDbContext<AbroadContext>(options => options.UseSqlite($"Data Source=./db/abroad.sqlite3;"));

            services.AddScoped<IRepository<School, SchoolId>, Repository<School, SchoolId>>();
            services.AddScoped<IUnityOfWork, EFCoreUnityOfWork>();
        }
    }
}