using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Application.Repositories.CarrierConfiguration;

namespace TransportManagement.Application.Features.Command.CarrierConfigurationCommand.CreateCarrierConfiguration
{
    public class CreateCarrierConfigurationCommandHandler : IRequestHandler<CreateCarrierConfigurationCommandRequest, CreateCarrierConfigurationCommandResponse>
    {
        readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public CreateCarrierConfigurationCommandHandler(ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        public async Task<CreateCarrierConfigurationCommandResponse> Handle(CreateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            await _carrierConfigurationWriteRepository.AddAsync(new()
            {
               CarrierMaxDesi = request.CarrierMaxDesi,
               CarrierMinDesi= request.CarrierMinDesi,
               CarrierCost = request.CarrierCost,
               CarrierId = request.CarrierId
            });

           await _carrierConfigurationWriteRepository.SaveAsync();

            return new()
            {
                Response = "Kayıt başarıyla oluşturuldu"
            };
        }
    }
}
