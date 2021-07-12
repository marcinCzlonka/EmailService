using EmailService.Shared_Kernel;
using Org.BouncyCastle.Utilities.Encoders;

namespace EmailService.Domain.Entities
{
    public class Attachment : Entity
    {
        public string Content { get; set; }
    }
}