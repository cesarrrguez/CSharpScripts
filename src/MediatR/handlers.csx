#load "interfaces.csx"
#load "events.csx"
#load "queries.csx"
#load "commands.csx"

using MediatR;
using AutoMapper;
using System.Threading;
using Microsoft.Extensions.Logging;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IMediator mediator)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<CustomerDto> Handle(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken)
    {
        Customer customer = _mapper.Map<Customer>(createCustomerCommand);

        await _customerRepository.Create(customer);

        await _mediator.Publish(new CustomerCreatedEvent(customer.FirstName, customer.LastName, customer.RegistrationDate), cancellationToken);

        return _mapper.Map<CustomerDto>(customer);
    }
}

public class CustomerCreatedLoggerHandler : INotificationHandler<CustomerCreatedEvent>
{
    private readonly ILogger<CustomerCreatedLoggerHandler> _logger;

    public CustomerCreatedLoggerHandler(ILogger<CustomerCreatedLoggerHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"New customer has been created at {notification.RegistrationDate}: {notification.FirstName} {notification.LastName}");

        return Task.CompletedTask;
    }
}

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        Customer customer = await _customerRepository.GetById(request.CustomerId)
            ?? throw new Exception("Customer with given ID is not found");

        return _mapper.Map<CustomerDto>(customer);
    }
}

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Customer> customers = await _customerRepository.GetAll();

        var result = new List<CustomerDto>();
        customers.ToList().ForEach(customer => result.Add(_mapper.Map<CustomerDto>(customer)));

        return result;
    }
}
