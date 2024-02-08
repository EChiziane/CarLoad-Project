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
    
    [HttpGet("today")]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<List<CarLoadDto>>> CarLoadsToday()
    {
        return Ok(await _mediator.Send(new GetCarLoadToday.GetCarLoadTodayQuery()));
    }

    [HttpGet("Range")]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<List<CarLoadDto>>> CarLoadsRange(DateTime startDate,DateTime endDate)
    {
        return Ok(await _mediator.Send(new GetCarLoadRange.GetCarLoadRangeQuery
            { StartDate = startDate, EndDate = endDate }));
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