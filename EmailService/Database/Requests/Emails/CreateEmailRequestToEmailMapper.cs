using EmailService.Common.Interfaces;
using EmailService.Database.Entities;

namespace EmailService.Database.Requests.Emails
{
    internal sealed class CreateEmailRequestToEmailMapper : IMapper<CreateEmailRequest, Email>
    {
        public void Map(CreateEmailRequest obj, Email output)
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