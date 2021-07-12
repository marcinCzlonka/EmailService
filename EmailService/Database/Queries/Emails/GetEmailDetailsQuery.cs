using EmailService.Domain.Entities;
using MediatR;

namespace EmailService.Database.Queries.Emails
{
    public sealed class GetEmailDetailsQuery : IRequest<Email>
    {
        public int Id { get; set; }
    }
}