using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmailService.Common.Interfaces;
using EmailService.Database.Entities;
using EmailService.Database.Queries.Emails;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailService.Database.Handlers
{
    internal sealed class GetAllEmailsQueryHandler : IRequestHandler<GetAllEmailsQuery, List<Email>>
    {
        private readonly ServiceContext _context;

        public GetAllEmailsQueryHandler(ServiceContext context)
        {
            _context = context;
        }

        public async Task<List<Email>> Handle(GetAllEmailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Emails.AsNoTracking().ToListAsync(cancellationToken);

            return result;
        }
    }
}