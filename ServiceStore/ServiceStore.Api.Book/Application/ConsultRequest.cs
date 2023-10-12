using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.Book.Models;
using ServiceStore.Api.Book.Persistence;

namespace ServiceStore.Api.Book.Application;

public class ConsultRequest
{
    public class BookList : IRequest<List<BookDto>>
    {
    }
    
    public class ManagerRequest : IRequestHandler<BookList, List<BookDto>>
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        public ManagerRequest(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> Handle(BookList request, CancellationToken cancellationToken)
        {
            var books = await _context.BookLibraries.ToListAsync();
            var booksDto = _mapper.Map<List<BookLibrary>, List<BookDto>>(books);
            
            return booksDto;
        }
    }
}