#load "data.csx"
#load "services.csx"

#r "nuget: LanguageExt.Core, 3.5.27-beta"

using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json;

using LanguageExt;

var customerService = new CustomerService(new CustomerRepository());

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

    Option<Customer> customerOption = customerService.Get(customerIdGuid);

    customerOption.IfNone(() => WriteLine("Customer not found"));

    customerOption.IfSome((customer) =>
    {
        var customerSerialized = JsonSerializer.Serialize(customer,
            new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            });

        WriteLine($"Customer: {customerSerialized}");
    });
}
