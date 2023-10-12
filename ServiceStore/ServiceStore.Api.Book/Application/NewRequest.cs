using FluentValidation;
using MediatR;
using ServiceStore.Api.Book.Models;
using ServiceStore.Api.Book.Persistence;

namespace ServiceStore.Api.Book.Application;

public class NewRequest
{
    public class RunRequest : IRequest
    {
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? BookAuthor { get; set; }
    }
    
    public class RunValidation : AbstractValidator<RunRequest>
    {
        public RunValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("'Nombre' no debe estar vacío");
            RuleFor(x => x.PublicationDate)
                .NotEmpty()
                .WithMessage("Debe agregar una fecha");
            RuleFor(x => x.BookAuthor)
                .NotEmpty()
                .WithMessage("Debe agregar un autor");
        }
    }
    
    public class ManagerRequest : IRequestHandler<RunRequest>
    {
        public readonly BookContext _bookcontext;

        public ManagerRequest(BookContext context)
        {
            _bookcontext = context;
        }
        
        public async Task<Unit> Handle(RunRequest request, CancellationToken cancellationToken)
        {
            var bookLibrary = new BookLibrary
            {
                Title = request.Title,
                PublicationDate = request.PublicationDate,
                BookAuthor = request.BookAuthor
            };

            _bookcontext.BookLibraries.Add(bookLibrary);
            var responseValue = await _bookcontext.SaveChangesAsync();

            if (responseValue > 0)
            {
                return Unit.Value;
            }

            throw new Exception("No se pudo guardar el Libro");
        }
    }
}