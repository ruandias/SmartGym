using Microsoft.Extensions.DependencyInjection;
using Infra.Shared.Contexts;

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
