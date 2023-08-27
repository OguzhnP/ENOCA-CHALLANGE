using TransportManagement.Application.Repositories.Carrier;
using TransportManagement.Entities.Entities;
using TransportManagement.Persistance.Context;

namespace TransportManagement.Persistance.Repositories.Carrier
{
    public class CarrierReadRepository : ReadRepository<Carriers>, ICarrierReadRepository
    {
        public CarrierReadRepository(TransportManagementDbContext context) : base(context)
        {
        }
    }
}
