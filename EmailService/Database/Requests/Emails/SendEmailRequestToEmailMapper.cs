using EmailService.Common.Interfaces;
using EmailService.Database.Entities;

namespace EmailService.Database.Requests.Emails
{
    internal sealed class SendEmailRequestToEmailMapper : IMapper<SendEmailRequest, Email>
    {
        public void Map(SendEmailRequest obj, Email output)
        {
            output.Id = obj.Id;
            output.Priority = obj.Priority;
            output.Recipients = obj.Recipients;
            output.Sender = obj.Sender;
            output.Send = obj.Send;
            output.Text = obj.Text;
            output.Attachment = obj.Attachment;
        }
    }
}