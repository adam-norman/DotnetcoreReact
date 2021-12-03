using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistance;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activites
{
public class List
    {
        public class Query : IRequest<List<Activity>>
        {

        }
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext dataContext;
            private readonly ILogger logger;

            public Handler(DataContext dataContext )
            {
                this.dataContext = dataContext;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await dataContext.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}
