#load "dtos.csx"
#load "queries.csx"
#load "commands.csx"
#load "interfaces.csx"
#load "handlers.csx"

using System.Collections.Generic;
using MediatR;

public class CustomerService : ICustomerService
{
    private readonly IMediator _mediator;

    public CustomerService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Create(CreateCustomerCommand createCustomerCommand)
    {
        await _mediator.Send(createCustomerCommand);
    }

    public async Task<CustomerDto> GetById(int customerId)
    {
        return await _mediator.Send(new GetCustomerByIdQuery(customerId));
    }

    public async Task<IEnumerable<CustomerDto>> GetAll()
    {
        return await _mediator.Send(new GetAllCustomersQuery());
    }
}
