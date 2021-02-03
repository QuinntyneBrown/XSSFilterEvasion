using FluentValidation;
using XSSFilterEvasion.Api.Data;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace XSSFilterEvasion.Api.Features
{
    public class RemoveToDo
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.ToDoId).NotEqual(default(Guid));
            }
        }

        public class Request : IRequest<Unit> {  
            public Guid ToDoId { get; set; }
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IXSSFilterEvasionDbContext _context;

            public Handler(IXSSFilterEvasionDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken) {

                var toDo = await _context.ToDos.FindAsync(request.ToDoId);

                toDo.Deleted = DateTime.Now;
                toDo.Modified = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return new();
            }
        }
    }
}
