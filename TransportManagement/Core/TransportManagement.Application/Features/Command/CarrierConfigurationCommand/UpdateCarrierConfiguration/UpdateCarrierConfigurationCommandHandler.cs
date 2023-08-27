using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Application.Repositories.CarrierConfiguration;
using TransportManagement.Entities.Entities;

namespace TransportManagement.Application.Features.Command.CarrierConfigurationCommand.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandHandler : IRequestHandler<UpdateCarrierConfigurationCommandRequest, UpdateCarrierConfigurationCommandResponse>
    {
        readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public UpdateCarrierConfigurationCommandHandler(ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository)
        {
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
        }

        public async Task<UpdateCarrierConfigurationCommandResponse> Handle(UpdateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            CarrierConfigurations carrierConfigurations = await _carrierConfigurationReadRepository.GetByIdAsync(request.Id);

            carrierConfigurations.CarrierMinDesi = request.CarrierMinDesi;
            carrierConfigurations.CarrierMaxDesi = request.CarrierMaxDesi;
            carrierConfigurations.CarrierCost = request.CarrierCost;
            carrierConfigurations.CarrierId= request.CarrierId;

            await _carrierConfigurationWriteRepository.SaveAsync();

            return new()
            {
                Response = $"{request.Id} numaralı kayıt güncellendi."
            };

        }
    }
}
