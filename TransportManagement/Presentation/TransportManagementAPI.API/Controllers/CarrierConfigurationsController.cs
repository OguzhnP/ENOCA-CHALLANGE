using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagement.Application.Features.Command.CarrierCommand.CreateCarrier;
using TransportManagement.Application.Features.Command.CarrierCommand.UpdateCarrier;
using TransportManagement.Application.Features.Command.CarrierConfigurationCommand.CreateCarrierConfiguration;
using TransportManagement.Application.Features.Command.CarrierConfigurationCommand.RemoveCarrierConfiguration;
using TransportManagement.Application.Features.Command.CarrierConfigurationCommand.UpdateCarrierConfiguration;
using TransportManagement.Application.Features.Command.OrderCommand.RemoveOrder;
using TransportManagement.Application.Features.Query.CarrierConfigurationQuery.GetCarrierConfigurations;
using TransportManagement.Application.Features.Query.CarrierQuery.GetCarriers;

namespace TransportManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationsController : ControllerBase
    {

        readonly IMediator _mediator;

        public CarrierConfigurationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCarrierConfigurationsQueryRequest getCarrierConfigurationsQueryRequest)
        {
            GetCarrierConfigurationsQueryResponse response = await _mediator.Send(getCarrierConfigurationsQueryRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCarrierConfigurationCommandRequest removeCarrierConfigurationCommandRequest)
        {
            RemoveCarrierConfigurationCommandResponse response = await _mediator.Send(removeCarrierConfigurationCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCarrierConfigurationCommandRequest createCarrierConfigurationCommandRequest)
        {
            CreateCarrierConfigurationCommandResponse response = await _mediator.Send(createCarrierConfigurationCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromBody] UpdateCarrierConfigurationCommandRequest updateCarrierConfigurationCommandRequest)
        {
            UpdateCarrierConfigurationCommandResponse response = await _mediator.Send(updateCarrierConfigurationCommandRequest);
            return Ok(response);
        }
    }
}
