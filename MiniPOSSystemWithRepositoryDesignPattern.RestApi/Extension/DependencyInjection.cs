﻿namespace MiniPOSSystemWithRepositoryDesignPattern.RestApi.Extension;

public static class DependencyInjection
{

    #region AddDependencyInjection

    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
    {
        return services
            .AddDbContextService(builder)
            .AddDataAccessService()
            .AddBusinessLogicService();
    }

	#endregion

	#region AddDbContextService

	private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
	{
		builder.Services
			.AddDbContext<AppDbContext>(opt =>
			{
				opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); // Add database provider
				opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			});

		builder.Services
			.AddControllers()
			.AddJsonOptions(opt =>
			{
				opt.JsonSerializerOptions.PropertyNamingPolicy = null;
			});

		return services;
	}

	#endregion

	#region AddDataAccessService

	private static IServiceCollection AddDataAccessService(this IServiceCollection services)
    {
        return services
        .AddScoped<IAdminRepository, AdminRepository>()
        .AddScoped<IProductRepository, ProductRepository>()
        .AddScoped<IProductCategoryRepository, ProductCategoryRepository>()
        .AddScoped<IInvoiceRepository, InvoiceRepository>()
        .AddScoped<ISaleRepository, SaleRepository>();

    }

    #endregion

    #region AddBusinessLogicService

    private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
    {
        return services
            .AddScoped<BL_Admin>()
            .AddScoped<BL_Product>()
            .AddScoped<BL_ProductCategory>()
            .AddScoped<BL_Invoice>()
            .AddScoped<BL_Sale>();

    }

    #endregion

}
