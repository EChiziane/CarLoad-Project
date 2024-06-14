using Application.Dtos;
using Application.Sprints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SprintController : ControllerBase
{
    private readonly IMediator _mediator;

    public SprintController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<List<SprintDto>>> GetAllSprints()
    {
        return Ok(await _mediator.Send(new GetSprints.GetSprintsQuery()));
    }

    [HttpPost]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<SprintDto>> CreateSprint(CreateSprint.CreateSprintCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<SprintDto>> DeleteSprint(int id)
    {
        return Ok(await _mediator.Send(new DeleteSprint.DeleteSprintCommand { SprintId = id }));
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<SprintDto>> GetSprintById(int id)
    {
        return Ok(await _mediator.Send(new GetSprintById.GetSprintByIdQuery { SprintId = id }));
    }
}