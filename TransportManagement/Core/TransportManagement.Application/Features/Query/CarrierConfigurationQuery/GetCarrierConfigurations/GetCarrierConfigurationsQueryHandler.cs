using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Application.Repositories.CarrierConfiguration;

namespace TransportManagement.Application.Features.Query.CarrierConfigurationQuery.GetCarrierConfigurations
{
    public class GetCarrierConfigurationsQueryHandler : IRequestHandler<GetCarrierConfigurationsQueryRequest, GetCarrierConfigurationsQueryResponse>
    {
         readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;

        public GetCarrierConfigurationsQueryHandler(ICarrierConfigurationReadRepository carrierConfigurationReadRepository)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
        }

        public async Task<GetCarrierConfigurationsQueryResponse> Handle(GetCarrierConfigurationsQueryRequest request, CancellationToken cancellationToken)
        {
            var carrierConfigurations = _carrierConfigurationReadRepository.GetAll(false)
                .Select(cf => new
                {
                    cf.Id,
                    cf.Carrier.CarrierName,
                    cf.CarrierCost,
                    cf.CarrierMinDesi,
                    cf.CarrierMaxDesi,
                    cf.CarrierId,
                    cf.CreatedDate,
                    cf.UpdatedDate
                }).ToList();

            return new()
            {
                CarrierConfigurations = carrierConfigurations,
            };
        }
    }
}
