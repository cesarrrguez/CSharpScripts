#load "entities.csx"

using LanguageExt;

public interface ICustomerRepository
{
    void Create(Customer customer);
    Option<Customer> Get(Guid customerId);
    IEnumerable<Customer> GetAll();
}

public interface ICustomerService
{
    void Create(Customer customer);
    Option<Customer> Get(Guid customerId);
    IEnumerable<Customer> GetAll();
}
