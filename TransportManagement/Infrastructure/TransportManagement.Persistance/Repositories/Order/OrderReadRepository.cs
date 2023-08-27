using TransportManagement.Application.Repositories.Order;
using TransportManagement.Entities.Entities;
using TransportManagement.Persistance.Context;

namespace TransportManagement.Persistance.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<Orders>, IOrderReadRepository
    {
        public OrderReadRepository(TransportManagementDbContext context) : base(context)
        {
        }
    }
}
