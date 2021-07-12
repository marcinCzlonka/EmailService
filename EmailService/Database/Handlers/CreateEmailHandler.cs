using System.Threading;
using System.Threading.Tasks;
using EmailService.Common.Interfaces;
using EmailService.Domain.Entities;
using EmailService.Database.Requests.Emails;
using MediatR;

namespace EmailService.Database.Handlers
{
    internal sealed class CreateEmailHandler : IRequestHandler<CreateEmailRequest, int>
    {
        private readonly IMapper<CreateEmailRequest, Email> _mapper;
        private readonly IEmailRepository _repository;

        public CreateEmailHandler(IEmailRepository repository, IMapper<CreateEmailRequest, Email> mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(CreateEmailRequest request, CancellationToken cancellationToken)
        {
            return await _repository.CreateEmail(_mapper.Map(request), cancellationToken);
        }
    }
}