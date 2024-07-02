using Application.Clients;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ClientController : BaseApiController
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<List<Client>>> GetAllClients()
    {
        return Ok(await _mediator.Send(new ListClients.ListClientsQuery()));
    }

    [HttpPost]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<Client>> CreateClient(CreateClient.CreateClientCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [Authorize]
    [AllowAnonymous]
    public async Task<Client> DeleteClient(int id)
    {
        return await _mediator.Send(new DeleteClient.DeleteClientCommand { ClientId = id });
    }

    [HttpGet("{id}")]
    [Authorize]
    [AllowAnonymous]
    public async Task<Client> GetClientById(int id)
    {
        return await _mediator.Send(new GetClientById.GetClientByIdQuery { ClientId = id });
    }

    [HttpGet("phone/{phoneNumber}")]
    [Authorize]
    [AllowAnonymous]
    public async Task<Client> GetClientByPhoneNumber(string phoneNumber)
    {
        return await _mediator.Send(
            new GetClientByNumberPhone.GetClientByNumberPhoneQuery { PhoneNumber = phoneNumber });
    }
}