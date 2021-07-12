using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmailService.Common.Interfaces;
using EmailService.Domain.Entities;
using EmailService.Database.Queries.Emails;
using MediatR;

namespace EmailService.Database.Handlers
{
    internal sealed class GetAllEmailsQueryHandler : IRequestHandler<GetAllEmailsQuery, IEnumerable<Email>>
    {
        private readonly IEmailRepository _repository;

        public GetAllEmailsQueryHandler(IEmailRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Email>> Handle(GetAllEmailsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllEmails(cancellationToken);
        }
    }
}