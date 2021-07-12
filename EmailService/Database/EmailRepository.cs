using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EmailService.Common.Interfaces;
using EmailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailService.Database
{
    public class EmailRepository : IEmailRepository
    {
        private ServiceContext context;
        private readonly IEmailSender _sender;
        private readonly IDbConnection _dbConnection;
        public EmailRepository(ServiceContext serviceContext, IEmailSender sender, IDbConnection dbConnection)
        {
            this.context = serviceContext;
            this._sender = sender;
            this._dbConnection = dbConnection;

        }

        public  async Task<Email> GetEmail(int id, CancellationToken cancellationToken)
        {
            var sql = @"SELECT  *
                        FROM Emails
                        LEFT JOIN EmailAddresses Addresses
                        ON Addresses.Id = Emails.SenderId
                        where Emails.Id = @Id";

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("Id", id);

            var result = await this._dbConnection.QueryAsync<Email, EmailAddress, Email>(sql, (email,adress)=> { email.Sender = adress; return email; }, dynamicParameters);
            return result.FirstOrDefault();
            
           // return await  context.Emails.AsNoTracking().SingleOrDefaultAsync(e=>e.Id == id, cancellationToken);
        }
        public virtual async Task<IEnumerable<Email>> GetAllEmails(CancellationToken cancellationToken)
        {
            var result = await context.Emails.AsNoTracking().ToListAsync(cancellationToken);
            return result;
        }

        public async Task<int> CreateEmail(Email email, CancellationToken cancellationToken)
        {
            context.EmailAddresses.Add(email.Sender);
            context.EmailAddresses.AddRange(email.Recipients);
            context.Attachments.Add(email.Attachment);
            context.Emails.Add(email);
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
