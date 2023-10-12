using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.Author.Models;
using ServiceStore.Api.Author.Persistence;

namespace ServiceStore.Api.Author.Application;

public class ConsultByFilter
{
    public class ConsultByAuthor : IRequest<AuthorDto>
    {
        public string AuthorGuid { get; set; }
    }
    
    public class ManagerRequest : IRequestHandler<ConsultByAuthor, AuthorDto>
    {
        private readonly AuthorContext _context;
        private readonly IMapper _mapper;

        public ManagerRequest(AuthorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(ConsultByAuthor request, CancellationToken cancellationToken)
        {
            var author = await _context.AuthorBooks.Where(x => x.AuthorBookGuid == request.AuthorGuid).FirstOrDefaultAsync();
            var authorDto = _mapper.Map<AuthorBook, AuthorDto>(author);

            if (author == null)
            {
                throw new Exception("No se encontro el Autor");
            }

            return authorDto;
        }
    }
}