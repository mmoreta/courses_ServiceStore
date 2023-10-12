using FluentValidation;
using MediatR;
using ServiceStore.Api.Author.Models;
using ServiceStore.Api.Author.Persistence;

namespace ServiceStore.Api.Author.Application;

public class NewRequest
{
    public class RunRequest : IRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
    
    public class RunValidation : AbstractValidator<RunRequest>
    {
        public RunValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("'Nombre' no debe estar vacío");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("'Apellido' no debe estar vacío");
        }
    }
    
    public class ManagerRequest : IRequestHandler<RunRequest>
    {
        public readonly AuthorContext _authorcontext;

        public ManagerRequest(AuthorContext context)
        {
            _authorcontext = context;
        }
        
        public async Task<Unit> Handle(RunRequest request, CancellationToken cancellationToken)
        {
            var authorBook = new AuthorBook
            {
                Name = request.Name,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                AuthorBookGuid = Convert.ToString(Guid.NewGuid())
            };

            _authorcontext.AuthorBooks.Add(authorBook);
            var responseValue = await _authorcontext.SaveChangesAsync();

            if (responseValue > 0)
            {
                return Unit.Value;
            }

            throw new Exception("No se pudo insertar el Autor del libro");
        }
    }
}