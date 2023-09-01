using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagement.Application.Features.Command.CarrierCommand.CreateCarrier;
using TransportManagement.Application.Features.Command.CarrierCommand.RemoveCarrier;
using TransportManagement.Application.Features.Command.CarrierCommand.UpdateCarrier;
using TransportManagement.Application.Features.Command.CarrierConfigurationCommand.UpdateCarrierConfiguration;
using TransportManagement.Application.Features.Command.OrderCommand.CreateOrder;
using TransportManagement.Application.Features.Query.CarrierQuery.GetCarriers;

namespace TransportManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        readonly IMediator _mediator;

        public CarriersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCarriersQueryRequest getCarriersQueryRequest)
        {
            GetCarriersQueryResponse response = await _mediator.Send(getCarriersQueryRequest);
            return Ok(response.Carriers);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCarrierCommandRequest createCarrierCommandRequest)
        {
            CreateCarrierCommandResponse response = await _mediator.Send(createCarrierCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCarrierCommandRequest removeCarrierCommandRequest)
        {
            RemoveCarrierCommandResponse response = await _mediator.Send(removeCarrierCommandRequest);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromBody] UpdateCarrierCommandRequest updateCarrierCommandRequest)
        {  
            UpdateCarrierCommandResponse response = await _mediator.Send(updateCarrierCommandRequest);
            return Ok(response);
        }
    }
}
