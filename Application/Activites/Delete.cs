using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activites
{
   public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity =await context.Activities.FindAsync(request.Id);
                context.Activities.Remove(activity);
                context.SaveChanges();
                return Unit.Value;
            }
        }

    }
}
