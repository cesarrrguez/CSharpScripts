#load "factories.csx"

ICreditCard creditCard = CreditCardFactory.Build(CreditCardType.Titanium);
WriteLine($"Credit Limit: {creditCard.CreditLimit}, Annual Charge: {creditCard.AnnualCharge}")
