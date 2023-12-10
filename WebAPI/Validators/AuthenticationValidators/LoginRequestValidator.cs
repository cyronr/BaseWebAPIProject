using FluentValidation;
using API.Requests.AuthenticationRequests;
using WebAPI.Validators.Utils;

namespace API.Validators.AuthenticationValidators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(obj => obj.Email)
            .NotEmpty()
            .WithMessage(ValidationMessages.PropertyMustHaveValue)
            .NotEqual(ValidationValues.DefaultString)
            .WithMessage(ValidationMessages.PropertyMustHaveValue);

        RuleFor(obj => obj.Password)
            .NotEmpty()
            .WithMessage(ValidationMessages.PropertyMustHaveValue)
            .NotEqual(ValidationValues.DefaultString)
            .WithMessage(ValidationMessages.PropertyMustHaveValue);
    }
}
