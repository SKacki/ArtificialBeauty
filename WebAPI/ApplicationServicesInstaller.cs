using DAL.Interfaces;
using DAL.Repos;
using Logic;
using Logic.Interfaces;

namespace WebAPI
{
    public static class ApplicationServicesInstaller
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Serwisy
            services.AddScoped<IModelSvc, ModelSvc>();
            //Repozytoria
            services.AddScoped<IModelRepository, ModelRepository>();

            return services;
        }
    }
}
