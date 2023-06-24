namespace webapi
{
    using Microsoft.EntityFrameworkCore;
    using System.Text.Json.Serialization;
    using webapi.Models;
    using webapi.Models.Repository;
    using webapi.Models.Repository.Interface;
    public static class StartUp
    {
        private static IConfiguration Configuration;

        public static void SetConfiguration(IConfiguration config)
        {
            Configuration = config;
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddDbContext<CyclixContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddScoped<IBikeTypeRepository, BikeTypeRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
        }

        public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
        {
            SetConfiguration(builder.Configuration);

            builder.Services.ConfigureServices();


            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder;
        }
    }
}

