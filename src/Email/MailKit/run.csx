#load "services.csx"

#r "nuget: MailKit, 2.13.0"

var mailService = new MailService();

mailService.SendMessage("James", "james@gmail.com", "César", "cesar.rrguez@gmail.com",
                        "Test email subject", "<p>Test email <strong>body</strong></p>");

WriteLine("POP 3:");
var messages = mailService.GetMessagesPop3();
messages.ForEach(message => WriteLine(message.Subject));

WriteLine("\nIMAP:");
messages = mailService.GetMessagesImap();
messages.ForEach(message => WriteLine(message.Subject));
