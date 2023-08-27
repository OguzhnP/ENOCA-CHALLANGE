using TransportManagement.Application.Repositories.Order;
using TransportManagement.Entities.Entities;
using TransportManagement.Persistance.Context;

namespace TransportManagement.Persistance.Repositories.Order
{
    public class OrderWriteRepository : WriteRepository<Orders>, IOrderWriteRepository
    {
        public OrderWriteRepository(TransportManagementDbContext context) : base(context)
        {
        }
    }
}
