using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmailService.Common.Interfaces;
using EmailService.Domain.Entities;
using EmailService.Database.Queries.Emails;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailService.Database.Handlers
{
    internal sealed class GetEmailDetailsQueryHandler : IRequestHandler<GetEmailDetailsQuery, Email>
    {
        private readonly IEmailRepository _repository;

        public GetEmailDetailsQueryHandler(IEmailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Email> Handle(GetEmailDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetEmail(request.Id, cancellationToken);
        }
    }
}