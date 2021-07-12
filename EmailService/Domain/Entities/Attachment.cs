using Org.BouncyCastle.Utilities.Encoders;

namespace EmailService.Domain.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}