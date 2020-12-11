#load "entities.csx"
#load "services.csx"

ILogger logger1 = new Logger1();
ILogger logger2 = new Logger2();

AbstractAccount simpleAccount = new SimpleAccount(logger1, 500);
simpleAccount.Withdraw(400);

simpleAccount.Logger = logger2;
simpleAccount.Withdraw(50);
simpleAccount.Withdraw(200);
