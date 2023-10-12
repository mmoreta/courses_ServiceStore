using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.Author.Models;
using ServiceStore.Api.Author.Persistence;

namespace ServiceStore.Api.Author.Application;

public class ConsultRequest
{
    public class AuthorList : IRequest<List<AuthorDto>>
    {
    }
    
    public class ManagerRequest : IRequestHandler<AuthorList, List<AuthorDto>>
    {
        private readonly AuthorContext _context;
        private readonly IMapper _mapper;

        public ManagerRequest(AuthorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<List<AuthorDto>> Handle(AuthorList request, CancellationToken cancellationToken)
        {
            var authors = await _context.AuthorBooks.ToListAsync();
            var authorsDto = _mapper.Map<List<AuthorBook>, List<AuthorDto>>(authors);

            return authorsDto;
        }
    }
}