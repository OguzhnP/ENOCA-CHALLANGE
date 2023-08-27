using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagement.Application.Features.Query.OrderQuery.GetOrders
{
    public class  GetOrdersQueryRequest : IRequest<GetOrdersQueryResponse>
    {
    }
}
