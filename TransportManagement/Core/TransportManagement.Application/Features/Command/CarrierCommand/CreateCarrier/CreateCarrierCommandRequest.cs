using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagement.Application.Features.Command.CarrierCommand.CreateCarrier
{
    public class CreateCarrierCommandRequest : IRequest<CreateCarrierCommandResponse>
    {
        [Required(AllowEmptyStrings = false)]
        public string CarrierName { get; set; }

        [Required]
        public bool CarrierIsActive { get; set; }

        [Required]
        public int CarrierPlusDesiCost { get; set; }
    }
}
