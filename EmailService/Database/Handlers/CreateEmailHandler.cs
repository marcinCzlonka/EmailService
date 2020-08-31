using System.Threading;
using System.Threading.Tasks;
using EmailService.Common.Interfaces;
using EmailService.Database.Entities;
using EmailService.Database.Requests.Emails;
using MediatR;

namespace EmailService.Database.Handlers
{
    internal sealed class CreateEmailHandler : IRequestHandler<CreateEmailRequest, int>
    {
        private readonly ServiceContext _context;
        private readonly IMapper<CreateEmailRequest, Email> _mapper;

        public CreateEmailHandler(ServiceContext context, IMapper<CreateEmailRequest, Email> mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEmailRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map(request);
            _context.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}