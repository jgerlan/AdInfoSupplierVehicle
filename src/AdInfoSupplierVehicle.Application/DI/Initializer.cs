using AdInfoSupplierVehicle.Domain.Interfaces;
using AdInfoSupplierVehicle.Domain.Models;
using AdInfoSupplierVehicle.Infrastructure.Context;
using AdInfoSupplierVehicle.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdInfoSupplierVehicle.Application
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conection));

            services.AddScoped(typeof(IRepository<Vehicle>), typeof(VehicleRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(VehicleService));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
