using Microsoft.EntityFrameworkCore;
using webapi.Models.Repository.Interface;
using webapi.Models.Repository;
using Microsoft.Extensions.Configuration;
using webapi.Models;

namespace webapi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureService(this IServiceCollection services) 
        {
            services.AddScoped<IBikeTypeRepository,BikeTypeRepository>();
            services.AddScoped<IBrandRepository,BrandRepository>();
        }

        public static void ConfigureContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CyclixContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("Default"));
            });
        }
    }
}
