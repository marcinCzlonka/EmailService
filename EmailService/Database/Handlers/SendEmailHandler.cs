using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmailService.Common.Interfaces;
using EmailService.Database.Entities;
using EmailService.Database.Requests.Emails;
using MediatR;

namespace EmailService.Database.Handlers
{
    internal sealed class SendEmailHandler : IRequestHandler<SendEmailRequest, int>
    {
        private readonly ServiceContext _context;
        private readonly IMapper<SendEmailRequest, Email> _mapper;
        private readonly IEmailSender _sender;

        public SendEmailHandler(ServiceContext context, IMapper<SendEmailRequest, Email> mapper, IEmailSender sender)
        {
            _context = context;
            _mapper = mapper;
            _sender = sender;
        }

        public async Task<int> Handle(SendEmailRequest request, CancellationToken cancellationToken)
        {
            var entity = _context.Emails.FirstOrDefault(i => i.Id == request.Id);
            if (entity == null)
            {
                entity = _mapper.Map(request);
                _context.Add(entity);
                _sender.Send(entity);
                entity.Send = true;
            }
            else
            {
                var newEntity = _mapper.Map(request);
                entity = newEntity;
                _sender.Send(entity);
                entity.Send = true;
            }

            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}