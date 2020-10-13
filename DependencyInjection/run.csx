// DI (Dependency Injection)
// --------------------------------------------------------
// It is a form of IoC, where implementations are passed to
// an object on which they "depend" to behave correctly.
// --------------------------------------------------------

#load "no.csx"
#load "yes.csx"

var user = new User
{
    Name = "César",
    Email = "cesar.rrguez@gmail.com",
    Phone = "123456789"
};

var newsletter = new Newsletter
{
    Description = "These are the weekly progress"
};

// No
var newsletterService = new NewsLetterService();
newsletterService.SendNewsLetter(user, newsletter);

// Yes
var messageSender = Factory.CreateMessageSender();

// Constructor injection
var newsletterService_DI = new NewsLetterService_DI(messageSender);
newsletterService_DI.SendNewsLetter(user, newsletter);

// Setter injection
var newsletterService_DI2 = new NewsLetterService_DI2();
newsletterService_DI2.SetMessageSender(messageSender);
newsletterService_DI2.SendNewsLetter(user, newsletter);

// Method injection 
var newsletterService_DI3 = new NewsLetterService_DI3();
newsletterService_DI3.SendNewsLetter(user, newsletter, messageSender);

// Interface injection
var newsletterService_DI4 = new NewsLetterService_DI4();
newsletterService_DI4.Inject(messageSender);
newsletterService_DI4.SendNewsLetter(user, newsletter);
