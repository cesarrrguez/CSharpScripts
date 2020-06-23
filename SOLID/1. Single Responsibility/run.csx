// SRP (Single Responsibility Principle)
// -------------------------------------------------
// A class should only have a single responsibility.
// -------------------------------------------------

#load "no.csx"
#load "yes.csx"
#load "data.csx"

string email = "cesar.rrguez@gmail.com";
string password = "MyPassword";

// No
var userService = new UserService(new UserRepository());
userService.RegisterNewUser(email, password);

// Yes
var userService_SRP = new UserService_SRP(new UserRepository());
userService_SRP.RegisterNewUser(email, password);
