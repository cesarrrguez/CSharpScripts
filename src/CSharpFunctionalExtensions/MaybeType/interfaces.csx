#load "entities.csx"

using CSharpFunctionalExtensions;

public interface ICustomerRepository
{
    void Create(Customer customer);

    Maybe<Customer> Get(Guid customerId);

    IEnumerable<Customer> GetAll();
}

public interface ICustomerService
{
    void Create(Customer customer);

    Maybe<Customer> Get(Guid customerId);

    IEnumerable<Customer> GetAll();
}
