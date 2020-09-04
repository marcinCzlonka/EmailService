using System.Collections.Generic;
using EmailService.Common.Interfaces;
using EmailService.Database.Entities;
using EmailService.Database.Enums;
using MediatR;

namespace EmailService.Database.Requests.Emails
{
    public class SendPendingEmailsRequest : IRequest<bool>
    {
        public ISMTPData Credentials { get; set; }
    }
}