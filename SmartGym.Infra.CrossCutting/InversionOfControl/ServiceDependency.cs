using Microsoft.Extensions.DependencyInjection;
using SmartGym.Domain.Interfaces;
using SmartGym.Service.Services;


namespace SmartGym.Infra.CrossCutting.InversionOfControl
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IServiceStudent, StudentService>();
            services.AddScoped<IServicePersonalTrainer, PersonalTrainerService>();
            services.AddScoped<IServiceTrainingCenter, TrainingCenterService>();
        }
    }
}
