using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Entities.Entities;

namespace TransportManagement.Application.Repositories.CarrierConfiguration
{
    public interface ICarrierConfigurationReadRepository : IReadRepository<CarrierConfigurations>
    {
    }
}