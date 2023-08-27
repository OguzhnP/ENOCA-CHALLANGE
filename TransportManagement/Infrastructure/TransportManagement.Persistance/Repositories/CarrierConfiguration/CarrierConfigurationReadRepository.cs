using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Application.Repositories.CarrierConfiguration;
using TransportManagement.Entities.Entities;
using TransportManagement.Persistance.Context;

namespace TransportManagement.Persistance.Repositories.CarrierConfiguration
{
    public class CarrierConfigurationReadRepository : ReadRepository<CarrierConfigurations>, ICarrierConfigurationReadRepository
    {
        public CarrierConfigurationReadRepository(TransportManagementDbContext context) : base(context)
        {
        }
    }
}
