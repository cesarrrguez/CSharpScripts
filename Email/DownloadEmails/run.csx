#load "utils.csx"

#r "nuget: OpenPop.NET, 2.0.6.1120"

var pop3 = new Pop3Util();
var messages = pop3.GetMessages();

foreach (var message in messages)
{
    WriteLine(message.Headers.Subject);
}
