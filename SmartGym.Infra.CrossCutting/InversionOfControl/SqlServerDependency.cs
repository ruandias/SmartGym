using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartGym.Infra.Data.Context;

namespace SmartGym.Infra.CrossCutting.InversionOfControl
{
    public static class SqlServerDependency
    {
        public static void AddSqlDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SmartGymCn")));
        }
    }

}
