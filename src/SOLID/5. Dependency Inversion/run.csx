// DIP (Dependency Inversion Principle)
// -------------------------------------------
// Depend on abstractions, not on concretions.
// -------------------------------------------

#load "no.csx"
#load "yes.csx"

string data = "Some data";

// No
var logic = new Logic();
logic.RegisterData(data);

// Yes
//var db = new MySqlDatabase();
var db = new OracleDatabase();
var logic_DIP = new Logic_DIP(db);

logic_DIP.RegisterData(data);
