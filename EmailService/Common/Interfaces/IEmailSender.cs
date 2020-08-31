using EmailService.Database.Entities;

namespace EmailService.Common.Interfaces
{
    internal interface IEmailSender
    {
        bool Send(Email email);
    }
}