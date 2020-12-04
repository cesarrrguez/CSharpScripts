#load "factories.csx"

// Titanium Credit Card Factory
CreditCardFactory titaniumCreditCardFactory = new TitaniumCreditCardFactory();
CreditCard titaniumCreditCard = titaniumCreditCardFactory.GetObject();
WriteLine(titaniumCreditCard);

// Platinum Credit Card Factory
CreditCardFactory platinumCreditCardFactory = new PlatinumCreditCardFactory();
CreditCard platinumCreditCard = platinumCreditCardFactory.GetObject();
WriteLine(platinumCreditCard);
