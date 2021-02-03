using FluentValidation;
using XSSFilterEvasion.Api.Data;
using XSSFilterEvasion.Api.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XSSFilterEvasion.Api.ValueObjects;

namespace XSSFilterEvasion.Api.Features
{
    public class CreateToDo
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ToDo).NotNull();
                RuleFor(request => request.ToDo).SetValidator(new ToDoValidator());
            }
        }

        public class Request : IRequest<Response> {  
            public ToDoDto ToDo { get; set; }
        }

        public class Response
        {
            public ToDoDto ToDo { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IXSSFilterEvasionDbContext _context;

            public Handler(IXSSFilterEvasionDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var toDo = new ToDo();

                _context.ToDos.Add(toDo);

                toDo.Name = request.ToDo.Name;

                // Extra protection 
                //toDo.HtmlBody = new Ganss.XSS.HtmlSanitizer().Sanitize(request.ToDo.HtmlBody);

                toDo.HtmlBody = (Html)request.ToDo.HtmlBody;

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    ToDo = toDo.ToDto()
                };
            }
        }
    }
}
