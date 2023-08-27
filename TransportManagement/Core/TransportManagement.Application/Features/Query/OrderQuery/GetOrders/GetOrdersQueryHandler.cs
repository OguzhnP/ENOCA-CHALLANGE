using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Application.Repositories.Order;

namespace TransportManagement.Application.Features.Query.OrderQuery.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQueryRequest, GetOrdersQueryResponse>
    {
         readonly IOrderReadRepository _orderReadRepository;

        public GetOrdersQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<GetOrdersQueryResponse> Handle(GetOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = _orderReadRepository.GetAll(false)
                .Select(o => new
                {
                    o.Id,
                    o.CarrierId,
                    o.Carrier.CarrierName,
                    o.OrderCarrierCost,
                    o.OrderDate,
                    o.OrderDesi,
                    o.CreatedDate,
                    o.UpdatedDate,
                }).ToList();

            return new()
            {
                Orders = orders
            };
        }
    }
}
