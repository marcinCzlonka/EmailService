using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmailService.Domain.Entities;

namespace EmailService.Common.Interfaces
{
    public interface IEmailRepository
    {
        Task<Email> GetEmail(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Email>> GetAllEmails(CancellationToken cancellationToken);
        Task<int> CreateEmail(Email email, CancellationToken cancellationToken);
        Task<bool> SendAllPendingEmails(ISMTPData credentials, CancellationToken cancellationToken);
    }
}