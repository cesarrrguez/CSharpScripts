#load "validators.csx"

#r "nuget: FluentValidation, 9.3.0"

using FluentValidation;

// Create data
var user = new User
{
    FirstName = "César",
    LastName = "Rodríguez",
    AccountBalance = 30,
    DateOfBirth = new DateOnly(2001, 01, 21),
    Addresses = new List<Address>()
    {
        new Address { City = "New York", Street = "1st Avenue" },
        new Address { City = "London", Street = "Oxford Street" }
    }
};

// Validate data
var validator = new UserValidator();
var results = validator.Validate(user);

if (!results.IsValid)
{
    foreach (var error in results.Errors)
    {
        WriteLine($"{error.PropertyName}: {error.ErrorMessage}");
    }
}
