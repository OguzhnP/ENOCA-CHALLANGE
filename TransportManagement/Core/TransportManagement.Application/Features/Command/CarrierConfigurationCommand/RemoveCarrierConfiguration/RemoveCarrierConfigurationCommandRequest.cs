using MediatR;

namespace TransportManagement.Application.Features.Command.CarrierConfigurationCommand.RemoveCarrierConfiguration
{
    public class RemoveCarrierConfigurationCommandRequest : IRequest<RemoveCarrierConfigurationCommandResponse>
    {
        public string Id { get; set; }
    }
}
