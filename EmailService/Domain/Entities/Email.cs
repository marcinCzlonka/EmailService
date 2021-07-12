using System.Collections.Generic;
using EmailService.Database.Enums;
using EmailService.Shared_Kernel;

namespace EmailService.Domain.Entities
{
    public class Email : Entity
    {
        public EmailAddress Sender { get; set; }
        public virtual ICollection<EmailAddress> Recipients { get; set; }
        public bool Send { get; set; }
        public string Text { get; set; }
        public Priority Priority { get; set; }
        public Attachment Attachment { get; set; }
        public string Subject { get; set; }
    }
}