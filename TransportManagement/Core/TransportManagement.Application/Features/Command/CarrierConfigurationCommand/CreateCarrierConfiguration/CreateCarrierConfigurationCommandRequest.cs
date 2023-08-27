using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagement.Application.Features.Command.CarrierConfigurationCommand.CreateCarrierConfiguration
{
    public class CreateCarrierConfigurationCommandRequest : IRequest<CreateCarrierConfigurationCommandResponse>
    {
        [Required]
        public int CarrierMaxDesi { get; set; }

        [Required]
        public int CarrierMinDesi { get; set; }

        [Required]
        public decimal CarrierCost { get; set; }

        [Required]
        public int CarrierId { get; set; }
    }
}
