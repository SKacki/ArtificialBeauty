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
            services.AddScoped<IUserSvc, UserSvc>();
            services.AddScoped<IModelSvc, ModelSvc>();
            services.AddScoped<IViewSvc, ViewSvc>();
            services.AddScoped<IImageSvc, ImageSvc>();
            services.AddScoped<IGeneratorSvc, GeneratorSvc>();
            //Repozytoria
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            return services;
        }
    }
}
