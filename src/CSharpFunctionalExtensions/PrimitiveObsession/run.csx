#load "../../../packages.csx"

#load "entities.csx"
#load "dtos.csx"

using CSharpFunctionalExtensions;

CreateCustomer(new CustomerDto { Name = "", Email = "cesar.rrguez@gmail.com" });
CreateCustomer(new CustomerDto { Name = "César", Email = "cesar.rrguez.com" });
CreateCustomer(new CustomerDto { Name = "César", Email = "cesar.rrguez@gmail.com" });

public void CreateCustomer(CustomerDto customerDto)
{
    Result<CustomerName> nameResult = CustomerName.Create(customerDto.Name);
    Result<Email> emailResult = Email.Create(customerDto.Email);

    if (nameResult.IsFailure)
    {
        WriteLine(nameResult.Error);
        return;
    }

    if (emailResult.IsFailure)
    {
        WriteLine(emailResult.Error);
        return;
    }

    Customer customer = new Customer(nameResult.Value, emailResult.Value);

    WriteLine(customer);
}
