using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagement.Application.Repositories.Carrier;
using TransportManagement.Application.Repositories.CarrierConfiguration;
using TransportManagement.Application.Repositories.Order;
using TransportManagement.Entities.Entities;

namespace TransportManagement.Application.Features.Command.OrderCommand.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly ICarrierReadRepository _carrierReadRepository;
        readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;

        public CreateOrderCommandHandler(ICarrierReadRepository carrierReadRepository, IOrderWriteRepository orderWriteRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository)
        {
            _carrierReadRepository = carrierReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var carrierPlusDesiCost = 0;
            var carreirId = 0;
            decimal carrierCost = 0;
            var differenceMinMax = 0;
            var carrierConfigurations = _carrierConfigurationReadRepository.GetAll(false)
                .Where(i => i.CarrierMinDesi <= request.OrderDesi && i.CarrierMaxDesi >= request.OrderDesi).ToList();


            if (carrierConfigurations != null && carrierConfigurations.Count > 0)
            {
                 
                var carrierConfiguration = carrierConfigurations.OrderBy(i => i.CarrierCost)
                    .FirstOrDefault();
                carrierCost = carrierConfiguration.CarrierCost;
                
                var carrier = await _carrierReadRepository.GetByIdAsync(carrierConfiguration.CarrierId.ToString(), tracking: false);
                carreirId = carrier.Id;
            }
            else
            {
                carrierConfigurations = _carrierConfigurationReadRepository.GetAll(false).ToList();
                CarrierConfigurations carrierConfiguration = null;
                var count = 9999;
                foreach (var cf in carrierConfigurations)
                {
                    if (Math.Abs(request.OrderDesi - cf.CarrierMinDesi) < count)
                    {
                        count = Math.Abs(request.OrderDesi - cf.CarrierMinDesi);
                        carrierConfiguration = cf;
                    }
                    if (Math.Abs(request.OrderDesi - cf.CarrierMaxDesi) < count)
                    {
                        count = Math.Abs(request.OrderDesi - cf.CarrierMaxDesi);
                        carrierConfiguration = cf;
                    }
                }
                if (carrierConfiguration != null)
                {
                    var carrier = await _carrierReadRepository.GetByIdAsync(carrierConfiguration.CarrierId.ToString(), tracking: false);
                    carreirId = carrier.Id;
                    carrierPlusDesiCost = carrier.CarrierPlusDesiCost;
                    carrierCost = carrierConfiguration.CarrierCost;
                    differenceMinMax = count == 9999 ? 0 : count;
                }
            }



            await _orderWriteRepository.AddAsync(new()
            {
                OrderDate = request.OrderDate,
                OrderDesi = request.OrderDesi,
                OrderCarrierCost = carrierCost + (carrierPlusDesiCost * differenceMinMax),
                CarrierId = carreirId
            }); ;

            await _orderWriteRepository.SaveAsync();
            return new()
            {
                Response = "Kayıt başarıyla oluşturuldu"
            };
        }
    }
}
