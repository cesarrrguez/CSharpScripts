#load "../../../packages.csx"

#load "services.csx"

var pop3Service = new Pop3Service();
var messages = pop3Service.GetMessages();
messages.ForEach(message => WriteLine(message.Headers.Subject));
