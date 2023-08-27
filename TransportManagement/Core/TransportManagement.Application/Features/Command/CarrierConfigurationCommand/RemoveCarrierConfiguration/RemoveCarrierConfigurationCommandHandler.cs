using MediatR;
using System.Runtime.CompilerServices;
using TransportManagement.Application.Repositories.CarrierConfiguration;

namespace TransportManagement.Application.Features.Command.CarrierConfigurationCommand.RemoveCarrierConfiguration
{
    public class RemoveCarrierConfigurationCommandHandler : IRequestHandler<RemoveCarrierConfigurationCommandRequest, RemoveCarrierConfigurationCommandResponse>
    {
         readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public RemoveCarrierConfigurationCommandHandler(ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        public async Task<RemoveCarrierConfigurationCommandResponse> Handle(RemoveCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            await _carrierConfigurationWriteRepository.RemoveAsync(request.Id);
            await _carrierConfigurationWriteRepository.SaveAsync();

            return new()
            {
                Response = $"{request.Id}  numaralı kayıt silindi."
            };

        }
    }
}
