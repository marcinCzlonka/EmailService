using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmailService.Common.Interfaces;
using EmailService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailService.Database
{
    public class EmailRepository : IEmailRepository
    {
        private ServiceContext context;
        private readonly IEmailSender _sender;
        public EmailRepository(ServiceContext serviceContext, IEmailSender sender)
        {
            this.context = serviceContext;
            this._sender = sender;
        }

        public async Task<Email> GetEmail(int id, CancellationToken cancellationToken)
        {
            return await  context.Emails.AsNoTracking().SingleOrDefaultAsync(e=>e.Id == id, cancellationToken);
        }
        public async Task<IEnumerable<Email>> GetAllEmails(CancellationToken cancellationToken)
        {
            var result = await context.Emails.AsNoTracking().ToListAsync(cancellationToken);
            return result;
        }

        public async Task<int> CreateEmail(Email email, CancellationToken cancellationToken)
        {
            context.Add(email);
            await context.SaveChangesAsync(cancellationToken);
            return email.Id;
        }

        public async Task<bool> SendAllPendingEmails(ISMTPData credentials, CancellationToken cancellationToken)
        {
            var emails = context.Emails.Where(e => e.Send == false).OrderByDescending(e => e.Priority);
            foreach (var email in emails)
            {
                _sender.Send(email, credentials);
                email.Send = true;
            }
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}
