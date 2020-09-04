using System;
using System.Net.Mail;
using EmailService.Common.Interfaces;
using EmailService.Database.Entities;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace EmailService.Common.DataClasses
{
    public class EmailSender : IEmailSender
    {
        public bool Send(Email email, ISMTPData credentials)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(email.Sender.Name, email.Sender.Value));
                message.Subject = email.Text;
                foreach (var recipient in email.Recipients)
                {
                    message.To.Add(new MailboxAddress(recipient.Name, recipient.Value));

                    message.Body = new TextPart("plain")
                    {
                        Text = email.Text
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect(credentials.SMTPAccount, 587, false);

                        // Note: only needed if the SMTP server requires authentication
                        client.Authenticate(credentials.Name, credentials.Password);

                        client.Send(message);
                        client.Disconnect(true);
                    }

                    return true;
                }
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                    ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }
    }
}