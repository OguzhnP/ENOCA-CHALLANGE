using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Application.Repositories.Carrier;

namespace TransportManagement.Application.Features.Command.CarrierCommand.RemoveCarrier
{
    public class RemoveCarrierCommandHandler : IRequestHandler<RemoveCarrierCommandRequest, RemoveCarrierCommandResponse>
    {
        readonly ICarrierWriteRepository _carrierWriteRepository;

        public RemoveCarrierCommandHandler(ICarrierWriteRepository carrierWriteRepository)
        {
            _carrierWriteRepository = carrierWriteRepository;
        }

        public async Task<RemoveCarrierCommandResponse> Handle(RemoveCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            await _carrierWriteRepository.RemoveAsync(request.Id);
            await _carrierWriteRepository.SaveAsync();

            return new()
            {
                Response = $"{request.Id} numaralı kayıt silindi."
            };
        }
    }
}
