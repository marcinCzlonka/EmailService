using EmailService.Shared_Kernel;

namespace EmailService.Domain.Entities
{
    public class EmailAddress : Entity
    {
        public string Value { get; set; }
        public string Name { get; set; }
    }
}