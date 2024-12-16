namespace MiniPOSSystemWithRepositoryDesignPattern.RestApi.Extension;

public static class DependencyInjection
{

    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
    {
        return services
            .AddDbContextService(builder)
            .AddDataAccessService()
            .AddBusinessLogicService();


    }
    private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services
         .AddDbContext<AppDbContext>(opt =>
         {
             opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
         })
         .AddControllers().AddJsonOptions(opt =>
         {
             opt.JsonSerializerOptions.PropertyNamingPolicy = null;
         });

        return services;
    }

    private static IServiceCollection AddDataAccessService(this IServiceCollection services)
    {
       
        return services
        .AddScoped<IAdminRepository, AdminRepository>();

    }

    private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
    {
        return services
            .AddScoped<BL_Admin>();
    }
}
