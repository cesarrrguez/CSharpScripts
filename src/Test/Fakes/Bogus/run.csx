#load "entities.csx"

#r "nuget: Bogus, 33.0.2"

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Bogus;

Randomizer.Seed = new Random(120);

var billingDetailsFaker = new Faker<BillingDetails>("es")
    .StrictMode(true)
    .RuleFor(x => x.CustomerName, f => f.Person.FullName)
    .RuleFor(x => x.Email, f => f.Person.Email)
    .RuleFor(x => x.Phones, f => Enumerable.Range(1, 3).Select(_ => f.Person.Phone).ToList())
    .RuleFor(x => x.AddressLine, f => f.Address.StreetAddress())
    .RuleFor(x => x.PostCode, f => f.Address.ZipCode())
    .RuleFor(x => x.City, f => f.Address.City())
    .RuleFor(x => x.Country, f => f.Address.Country())
;

var orderFaker = new Faker<Order>("es")
    .StrictMode(true)
    .RuleFor(x => x.Id, Guid.NewGuid)
    .RuleFor(x => x.Currency, f => f.Finance.Currency().Code)
    .RuleFor(x => x.Price, f => f.Finance.Amount(5, 100))
    .RuleFor(x => x.IsPaid, f => f.Random.Bool())
    .RuleFor(x => x.BillingDetails, _ => billingDetailsFaker)
    .FinishWith((_, x) => WriteLine($"Created a new order with Id: {x.Id}"))
;

var orders = orderFaker.Generate(10);

foreach (var order in orders)
{
    var text = JsonSerializer.Serialize(order,
        new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        });

    WriteLine();
    WriteLine(text);

    await Task.Delay(1000).ConfigureAwait(false);
}
