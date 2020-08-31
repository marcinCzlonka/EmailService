using System.Collections.Generic;
using EmailService.Database.Entities;
using EmailService.Database.Enums;
using MediatR;

namespace EmailService.Database.Requests.Emails
{
    public class SendEmailRequest : IRequest<int>
    {
        public int Id { get; set; }
        public EmailAddress Sender { get; set; }
        public virtual ICollection<EmailAddress> Recipients { get; set; }
        public bool Send { get; set; }
        public string Text { get; set; }
        public Priority Priority { get; set; }
        public Attachment Attachment { get; set; }
    }
}