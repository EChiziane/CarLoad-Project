using Application.Drivers;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class DriverController : BaseApiController
{
    private readonly IMediator _mediator;

    public DriverController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<List<Driver>>> GetAllDrivers()
    {
        return Ok(await _mediator.Send(new ListDrivers.ListDriversQuery()));
    }

    [HttpPost]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<Driver>> CreateDriver(CreateDriver.CreateDriverCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [AllowAnonymous]
    public async Task<Driver> DeleteDriver(int id)
    {
        return await _mediator.Send(new DeleteDriver.DeleteDriverCommand { DriverId = id });
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<Driver> GetDriverById(int id)
    {
        return await _mediator.Send(new GetDriverById.GetDriverByIdQuery { DriverId = id });
    }
}