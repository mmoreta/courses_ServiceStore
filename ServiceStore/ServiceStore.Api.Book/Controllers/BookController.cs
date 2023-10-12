using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceStore.Api.Book.Application;

namespace ServiceStore.Api.Book.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<BookDto>>> GetBooks()
    {
        return await _mediator.Send(new ConsultRequest.BookList());
    }
    
    [HttpPost]
    public async Task<ActionResult<Unit>> Create(NewRequest.RunRequest data)
    {
        return await _mediator.Send(data);
    }
}