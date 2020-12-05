#load "services.csx"

// Titanium Factory
BankFactory titaniumFactory = new TitaniumFactory();
var titaniumClient = new ClientService(titaniumFactory);
titaniumClient.Print();

WriteLine();

// Platinum Factory
BankFactory platinumFactory = new PlatinumFactory();
var platinumClient = new ClientService(platinumFactory);
platinumClient.Print();
