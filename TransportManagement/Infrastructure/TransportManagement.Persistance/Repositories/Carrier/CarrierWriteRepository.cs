using TransportManagement.Application.Repositories.Carrier;
using TransportManagement.Entities.Entities;
using TransportManagement.Persistance.Context;

namespace TransportManagement.Persistance.Repositories.Carrier
{
    public class CarrierWriteRepository : WriteRepository<Carriers>, ICarrierWriteRepository
    {
        public CarrierWriteRepository(TransportManagementDbContext context) : base(context)
        {
        }
    }
}
