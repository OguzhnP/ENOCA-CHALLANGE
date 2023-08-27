using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Application.Repositories.Carrier;
using TransportManagement.Entities.Entities;

namespace TransportManagement.Application.Features.Command.CarrierCommand.UpdateCarrier
{
    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommandRequest, UpdateCarrierCommandResponse>
    {
        readonly ICarrierReadRepository _carrierReadRepository;
        readonly ICarrierWriteRepository _carrierWriteRepository;

        public UpdateCarrierCommandHandler(ICarrierWriteRepository carrierWriteRepository, ICarrierReadRepository carrierReadRepository)
        {
            _carrierWriteRepository = carrierWriteRepository;
            _carrierReadRepository = carrierReadRepository;
        }

        public async Task<UpdateCarrierCommandResponse> Handle(UpdateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            Carriers carrier = await _carrierReadRepository.GetByIdAsync(request.Id);

            carrier.CarrierPlusDesiCost = request.CarrierPlusDesiCost;
            carrier.CarrierIsActive = request.CarrierIsActive;
            carrier.CarrierName = request.CarrierName;

            await _carrierWriteRepository.SaveAsync();

            return new()
            {
                Response = $"{request.Id} numaralı kayıt güncellendi."
            };
        }
    }
}
