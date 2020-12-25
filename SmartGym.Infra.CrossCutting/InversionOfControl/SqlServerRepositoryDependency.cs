using Microsoft.Extensions.DependencyInjection;
using SmartGym.Domain.Interfaces;
using SmartGym.Infra.Data.Repository;

namespace SmartGym.Infra.CrossCutting.InversionOfControl
{
    public static class SqlServerRepositoryDependency
    {
        public static void AddSqlServerRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryStudent, StudentRepository>();
        }
    }
}
