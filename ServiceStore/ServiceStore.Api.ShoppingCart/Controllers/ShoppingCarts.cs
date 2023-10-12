using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceStore.Api.ShoppingCart.Application;

namespace ServiceStore.Api.ShoppingCart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingCartsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ShoppingCartsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Create(NewRequest.RunRequest data)
    {
        return await _mediator.Send(data);
    } 
}