#load "dtos.csx"

using MediatR;

public record GetCustomerByIdQuery(int CustomerId) : IRequest<CustomerDto>;

public record GetAllCustomersQuery() : IRequest<IEnumerable<CustomerDto>>;
