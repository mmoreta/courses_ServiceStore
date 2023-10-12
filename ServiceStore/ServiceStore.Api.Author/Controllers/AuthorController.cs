using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceStore.Api.Author.Application;

namespace ServiceStore.Api.Author.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
    {
        return await _mediator.Send(new ConsultRequest.AuthorList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> GetAuthorByGuid(string id)
    {
        return await _mediator.Send(new ConsultByFilter.ConsultByAuthor { AuthorGuid = id });
    }
    
    [HttpPost]
    public async Task<ActionResult<Unit>> Create(NewRequest.RunRequest data)
    {
        return await _mediator.Send(data);
    }
}