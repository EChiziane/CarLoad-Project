using Application.Materials;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MaterialController : BaseApiController
{
    private readonly IMediator _mediator;

    public MaterialController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<List<Material>>> GetAllMaterials()
    {
        return Ok(await _mediator.Send(new ListMaterials.ListMaterialsQuery()));
    }

    [HttpPost]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<Material>> CreateMaterial(CreateMaterial.CreateMaterialCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [Authorize]
    [AllowAnonymous]
    public async Task<Material> DeleteMaterial(int id)
    {
        return await _mediator.Send(new DeleteMaterial.DeleteMaterialCommand { MaterialId = id });
    }

    [HttpGet("{id}")]
    [Authorize]
    [AllowAnonymous]
    public async Task<Material> GetMaterialById(int id)
    {
        return await _mediator.Send(new GetMaterialById.GetMaterialByIdQuery { MaterialId = id });
    }
}