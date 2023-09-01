#load "entities.csx"

using FluentValidation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("{PropertyName} is empty")
            .Length(2, 50).WithMessage("Length ({TotalLength}) of {PropertyName} invalid")
            .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

        RuleFor(x => x.LastName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("{PropertyName} is empty")
            .Length(2, 50).WithMessage("Length ({TotalLength}) of {PropertyName} invalid")
            .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

        RuleFor(x => x.AccountBalance)
            .Cascade(CascadeMode.Stop)
            .NotEqual(30).When(u => DateOnly.FromDateTime(DateTime.Now) <= u.DateOfBirth.AddYears(18)).WithMessage("{PropertyName} can´t be 30 if less than 18 years")
            .LessThanOrEqualTo(50).WithMessage("{PropertyName} must be less or equal to 50")
            .GreaterThan(20).WithMessage("{PropertyName} must be greater than 20");

        RuleFor(x => x.DateOfBirth)
            .Must(BeAValidAge).WithMessage("Invalid {PropertyName}");

        RuleFor(x => x.Addresses)
            .Must(x => x.Count <= 5).WithMessage("No more than 5 addresses are allowed");

        RuleForEach(x => x.Addresses).NotNull().WithMessage("Address {CollectionIndex} is required");
        RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
    }

    protected bool BeAValidName(string name)
    {
        name = name.Replace(" ", "");
        name = name.Replace("-", "");

        return name.All(char.IsLetter);
    }

    protected bool BeAValidAge(DateOnly date)
    {
        var currentYear = DateTime.Now.Year;
        var year = date.Year;

        return year <= currentYear && year > (currentYear - 120);
    }
}

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.City)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("{PropertyName} is empty")
            .Length(2, 50).WithMessage("Length ({TotalLength}) of {PropertyName} invalid");

        RuleFor(x => x.Street)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("{PropertyName} is empty")
            .Length(2, 50).WithMessage("Length ({TotalLength}) of {PropertyName} invalid");
    }
}
