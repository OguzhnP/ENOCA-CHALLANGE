using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagement.Application.Features.Command.CarrierCommand.RemoveCarrier;
using TransportManagement.Application.Features.Command.OrderCommand.CreateOrder;
using TransportManagement.Application.Features.Command.OrderCommand.RemoveOrder;
using TransportManagement.Application.Features.Query.CarrierConfigurationQuery.GetCarrierConfigurations;
using TransportManagement.Application.Features.Query.OrderQuery.GetOrders;

namespace TransportManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetOrdersQueryRequest getOrdersQueryRequest)
        {
            GetOrdersQueryResponse response = await _mediator.Send(getOrdersQueryRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveOrderCommandRequest removeOrderCommandRequest)
        {
            RemoveOrderCommandResponse response = await _mediator.Send(removeOrderCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
