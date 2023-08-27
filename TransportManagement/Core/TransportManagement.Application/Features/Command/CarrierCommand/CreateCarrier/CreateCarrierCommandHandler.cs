using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Application.Repositories.Carrier;

namespace TransportManagement.Application.Features.Command.CarrierCommand.CreateCarrier
{
    public class CreateCarrierCommandHandler : IRequestHandler<CreateCarrierCommandRequest, CreateCarrierCommandResponse>
    {
        readonly ICarrierWriteRepository _carrierWriteRepository;

        public CreateCarrierCommandHandler(ICarrierWriteRepository carrierWriteRepository)
        {
            _carrierWriteRepository = carrierWriteRepository;
        }

        public async Task<CreateCarrierCommandResponse> Handle(CreateCarrierCommandRequest request, CancellationToken cancellationToken)
        {

            await _carrierWriteRepository.AddAsync(new()
            {
                CarrierIsActive = request.CarrierIsActive,
                CarrierName = request.CarrierName,  
                CarrierPlusDesiCost = request.CarrierPlusDesiCost,
            });

            await _carrierWriteRepository.SaveAsync();

            return new()
            {
                Response = "Kayıt başarıyla oluşturuldu"
            };
        }
    }
}
