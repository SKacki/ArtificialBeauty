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
            services.AddScoped<IOperationSvc, OperationSvc>();
            services.AddScoped<IGeneratorSvc, GeneratorSvc>();
            //Repozytoria
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            //inne
            services.AddScoped<IGeneratorClient, MockClient>();

            return services;
        }
    }
}
