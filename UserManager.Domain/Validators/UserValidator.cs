using FluentValidation;
using UserManager.Domain.Entities;

namespace UserManager.Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Id cannot be null.");
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty.");

        RuleFor(x => x.BirthDate).NotNull().WithMessage("BirthDate cannot be null.");
        RuleFor(x => x.BirthDate).NotEmpty().WithMessage("BirthDate cannot be empty.");

        RuleFor(x => x.CPF).NotNull().WithMessage("CPF cannot be null.");
        RuleFor(x => x.CPF).NotEmpty().WithMessage("CPF cannot be empty.");

        RuleFor(x => x.FullName).NotNull().WithMessage("FullName cannot be null.");
        RuleFor(x => x.FullName).NotEmpty().WithMessage("FullName cannot be empty.");

        RuleFor(x => x.Email).NotNull().WithMessage("Email cannot be null.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty.");

        RuleFor(x => x.Password).NotNull().WithMessage("Password cannot be null.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty.");

        RuleFor(x => x.PhoneNumber).NotNull().WithMessage("PhoneNumber cannot be null.");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber cannot be empty.");

        RuleFor(x => x.Address).NotNull().WithMessage("Address cannot be null.");
        RuleFor(x => x.Address).NotEmpty().WithMessage("Address cannot be empty.");

        RuleFor(x => x.CreatedAt).NotNull().WithMessage("CreatedAt cannot be null.");
        RuleFor(x => x.CreatedAt).NotEmpty().WithMessage("CreatedAt cannot be empty");
    }
}
