using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagement.Application.Features.Command.CarrierConfigurationCommand.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandRequest : IRequest<UpdateCarrierConfigurationCommandResponse>
    {
        public string Id { get; set; }
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }
        public int CarrierId { get; set; }
    }
}
