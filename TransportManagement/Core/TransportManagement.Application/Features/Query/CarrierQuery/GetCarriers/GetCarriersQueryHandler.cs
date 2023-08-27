using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Application.Repositories.Carrier;

namespace TransportManagement.Application.Features.Query.CarrierQuery.GetCarriers
{
    public class GetCarriersQueryHandler : IRequestHandler<GetCarriersQueryRequest, GetCarriersQueryResponse>
    {
        readonly ICarrierReadRepository _carrierReadRepository;

        public GetCarriersQueryHandler(ICarrierReadRepository carrierReadRepository)
        {
            _carrierReadRepository = carrierReadRepository;
        }

        public async Task<GetCarriersQueryResponse> Handle(GetCarriersQueryRequest request, CancellationToken cancellationToken)
        {
            var carriers = _carrierReadRepository.GetAll(false).Select(c => new
            {
                c.Id,
                c.CarrierName,
                c.CarrierIsActive,
                c.CarrierPlusDesiCost,
                c.CarrierConfigurations,
            }).ToList();

            return new()
            {
                Carriers = carriers
            };
        }
    }
}
