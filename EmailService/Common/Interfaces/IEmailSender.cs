using EmailService.Database.Entities;

namespace EmailService.Common.Interfaces
{
    public interface IEmailSender
    {
        bool Send(Email email, ISMTPData credentials);
    }
}