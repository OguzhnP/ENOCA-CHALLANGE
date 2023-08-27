using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagement.Application.Features.Command.CarrierCommand.RemoveCarrier
{
    public class RemoveCarrierCommandRequest : IRequest<RemoveCarrierCommandResponse>
    {
        public string Id { get; set; }
    }
}
