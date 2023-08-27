using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagement.Application.Features.Command.CarrierCommand.UpdateCarrier
{
    public class UpdateCarrierCommandRequest : IRequest<UpdateCarrierCommandResponse>
    {

        public string Id { get; set; }

        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }

        public int CarrierPlusDesiCost { get; set; }
    }
}
