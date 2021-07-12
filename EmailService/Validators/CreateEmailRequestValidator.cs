using EmailService.Database.Requests.Emails;
using FluentValidation;

namespace EmailService.Validators
{
    public class CreateEmailRequestValidator : AbstractValidator<CreateEmailRequest>
    {
        public CreateEmailRequestValidator()
        {
            RuleFor(x => x.Sender.Value)
                .NotEmpty();
                //.Matches("^[a-zA-Z0-9]*$");
        }
    }
}
