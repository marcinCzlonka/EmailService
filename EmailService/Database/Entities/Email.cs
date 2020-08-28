using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailService.Database.Entities
{
    public class Email
    {
        public int Id { get; set; }
        public EmailAddress Sender { get; set; }
        public virtual ICollection<EmailAddress> Recipients { get; set; }
        public bool Send { get; set; }
        public string Text { get; set; }

        
    }
}
