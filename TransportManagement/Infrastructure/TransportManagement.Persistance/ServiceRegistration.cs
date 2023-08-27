 
using Microsoft.Extensions.DependencyInjection; 
using TransportManagement.Application.Repositories.Order; 
using TransportManagement.Application.Repositories.CarrierConfiguration;
using TransportManagement.Application.Repositories.Carrier;
using TransportManagement.Persistance.Repositories.Order;
using TransportManagement.Persistance.Repositories.CarrierConfiguration;
using TransportManagement.Persistance.Repositories.Carrier;
using TransportManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace TransportManagement.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TransportManagementDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<ICarrierConfigurationReadRepository, CarrierConfigurationReadRepository>();
            services.AddScoped<ICarrierConfigurationWriteRepository, CarrierConfigurationWriteRepository>();

            services.AddScoped<ICarrierReadRepository, CarrierReadRepository>(); 
            services.AddScoped<ICarrierWriteRepository, CarrierWriteRepository>(); 
        }

    }
}
