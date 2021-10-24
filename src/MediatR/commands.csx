#load "dtos.csx"

using MediatR;
using FluentValidation;

public record CreateCustomerCommand(string FirstName, string LastName) : IRequest<CustomerDto>;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(customer => customer.FirstName).NotEmpty();
        RuleFor(customer => customer.LastName).NotEmpty();
    }
}
