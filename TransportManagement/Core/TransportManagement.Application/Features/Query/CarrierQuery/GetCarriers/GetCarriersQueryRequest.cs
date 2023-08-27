using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagement.Application.Features.Query.CarrierQuery.GetCarriers
{
    public class GetCarriersQueryRequest : IRequest<GetCarriersQueryResponse>
    {
    }
}
