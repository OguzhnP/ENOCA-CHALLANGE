using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TransportManagement.Application.Features.Command.OrderCommand.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        [Required]
        public int OrderDesi { get; set; }

        public DateTime OrderDate { get; set; }= DateTime.Now;  

    }
}
