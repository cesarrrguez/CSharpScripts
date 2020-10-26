#load "services.csx"

#r "nuget: OpenPop.NET, 2.0.6.1120"

var pop3Service = new Pop3Service();
var messages = pop3Service.GetMessages();

foreach (var message in messages)
{
    WriteLine(message.Headers.Subject);
}
