#load "data.csx"
#load "services.csx"

string data = "Some data";

IDatabase db = new OracleDatabase();

// Constructor Injector
var service = new Service(db);

service.RegisterData(data);
