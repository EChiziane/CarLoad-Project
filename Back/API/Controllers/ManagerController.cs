using Application.Managers;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ManagerController : BaseApiController
{
    private readonly IMediator _mediator;

    public ManagerController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<List<Manager>>> GetManagers()
    {
        return Ok(await _mediator.Send(new ListManagers.ListManagersQuery()));
    }

    [HttpPost]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<Manager>> CreateManager(CreateManager.CreateManagerCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [Authorize]
    [AllowAnonymous]
    public async Task<Manager> DeleteManager(int id)
    {
        return await _mediator.Send(new DeleteManager.DeleteManagerCommand { ManagerId = id });
    }

    [HttpGet("{id}")]
    [Authorize]
    [AllowAnonymous]
    public async Task<Manager> GetManagerById(int id)
    {
        return await _mediator.Send(new GetManagerById.GetManagerByIdQuery { ManagerId = id });
    }
}