using MediatR;

public record CustomerCreatedEvent(string FirstName, string LastName, DateTime RegistrationDate) : INotification;
