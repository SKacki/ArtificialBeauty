namespace WebAPI
{
    public static class ApplicationServicesInstaller
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Serwisy
            //services.AddScoped<IUzytkownicySvc, UzytkownicySvc>();
            //Repozytoria

            //costam
            //services.AddKeyedTransient<IAkcjaTransferu, WyslijDoPrzypisanego>(AkcjaTransferuKlucz.WYSLIJ_DO_PRZYPISANEGO);

            return services;
        }
    }
}
