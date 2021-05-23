using Baram.Application.Common.Interfaces;
using Baram.Infrastructure.Persistence;
using Baram.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Baram.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            //{
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseInMemoryDatabase("SmartRentDb"));
            //}
            //else
            //{
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(
            //            configuration.GetConnectionString("DefaultConnection"),
            //            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            //}

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IDateTimeService, DateTimeService>();

            return services;
        }
    }
}
