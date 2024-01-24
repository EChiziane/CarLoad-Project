using Application.CarLoads;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CarloadController : BaseApiController
{
    private readonly IMediator _mediator;

    public CarloadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<List<CarLoadDto>>> CarLoads()
    {
        return Ok(await _mediator.Send(new ListCarload.ListCarloadQuery()));
    }


    [HttpPost]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<CarLoad>> CarLoad(CreateCarLoad.CreateCarLoadCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<CarLoad> GetCarLoadById(int id)
    {
        return await _mediator.Send(new GetCarloadById.GetCarLoadByIdQuery { CarLoadId = id });
    }
}