using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmailService.Common.Interfaces;
using EmailService.Database.Entities;
using EmailService.Database.Requests.Emails;
using MediatR;

namespace EmailService.Database.Handlers
{
    internal sealed class SendPendingEmailsHandler : IRequestHandler<SendPendingEmailsRequest, bool>
    {
        private readonly IEmailRepository _repository;

        public SendPendingEmailsHandler(IEmailRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(SendPendingEmailsRequest request, CancellationToken cancellationToken)
        {
            return await _repository.SendAllPendingEmails(request.Credentials,cancellationToken);
        }
    }
}