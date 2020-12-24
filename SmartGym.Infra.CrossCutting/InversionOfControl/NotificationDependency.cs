using Microsoft.Extensions.DependencyInjection;
using SmartGym.Infra.Shared.Contexts;

namespace SmartGym.Infra.CrossCutting.InversionOfControl
{
    public static class NotificationDependency
    {
        public static void AddNotificationDependency(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
        }
    }
}
