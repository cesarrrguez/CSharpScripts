#load "data.csx"
#load "services.csx"

#r "nuget: CSharpFunctionalExtensions, 2.16.0"

using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json;

using CSharpFunctionalExtensions;

var customerService = new CustomerService(new CustomerRepository());

GetCustomer("1234");
GetCustomer("00000000-0000-1111-0000-000000000000");
GetCustomer("00000000-1111-2222-3333-000000000000");

WriteLine();

GetCustomer("1234");
GetCustomer("00000000-0000-1111-0000-000000000000");
GetCustomer("00000000-1111-2222-3333-000000000000");

public void GetCustomer(string customerId)
{
    if (!Guid.TryParse(customerId, out var customerIdGuid))
    {
        WriteLine("Invalid customer id format");
        return;
    }

    Maybe<Customer> customerOrNothing = customerService.Get(customerIdGuid);

    if (customerOrNothing.HasNoValue)
    {
        WriteLine("Customer not found");
        return;
    }

    var customerSerialized = JsonSerializer.Serialize(customerOrNothing,
        new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        });

    WriteLine($"Customer: {customerSerialized}");
}

public void GetCustomer2(string customerId)
{
    if (!Guid.TryParse(customerId, out var customerIdGuid))
    {
        WriteLine("Invalid customer id format");
        return;
    }

    Maybe<Customer> customerOrNothing = customerService.Get(customerIdGuid);

    customerOrNothing.Match(
                Some: (customer) =>
                {
                    var customerSerialized = JsonSerializer.Serialize(customer,
                            new JsonSerializerOptions()
                            {
                                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                            });

                    WriteLine($"Customer: {customerSerialized}");
                },
                None: () => WriteLine("Customer not found")
            );
}
