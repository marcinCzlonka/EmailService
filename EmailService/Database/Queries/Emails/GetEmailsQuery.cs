using System.Collections.Generic;
using EmailService.Database.Entities;
using MediatR;

namespace EmailService.Database.Queries.Emails
{
    public class GetAllEmailsQuery : IRequest<IEnumerable<Email>>
    {
    }
}