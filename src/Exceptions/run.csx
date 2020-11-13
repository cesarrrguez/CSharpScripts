#load "entities.csx"
#load "exceptions.csx"

using System.Collections;

var separator = new string(Enumerable.Repeat('-', 67).ToArray());

var heating = new Heating("Cool Heating X", 20);

try
{
    for (int i = 0; i < 10; i++)
    {
        heating.Work(20);
    }

    //heating.Work(-1); // throw ArgumentException
}
catch (HeatingException e)
{
    WriteLine("\nHeatingException succeed");
    WriteLine(separator);
    Console.ForegroundColor = ConsoleColor.Red;

    WriteLine("Class: {0}", e.TargetSite.DeclaringType);
    WriteLine("Type: {0}", e.TargetSite.MemberType);
    WriteLine("Method: {0}", e.TargetSite);
    WriteLine("Source: {0}", e.Source);
    WriteLine("Stack: {0}", e.StackTrace);
    WriteLine("Help link: {0}", e.HelpLink);

    WriteLine("Message: {0}", e.Message);
    WriteLine("Time: {0}", e.Time);
    WriteLine("Reason: {0}", e.Reason);

    if (e.Data != null)
    {
        foreach (DictionaryEntry item in e.Data)
        {
            WriteLine("{0} {1}", item.Key, item.Value);
        }
    }
}
catch (ArgumentException e)
{
    WriteLine("\nArgument Exception succeed");
    WriteLine(separator);

    WriteLine("Message: {0}", e.Message);
}
catch (Exception e) when (e.GetType() != typeof(FormatException))
{
    WriteLine("\nException (Not FormatException) succeed");
    WriteLine(separator);

    WriteLine("Message: {0}", e.Message);
}
catch (Exception e)
{
    WriteLine("\nException succeed");
    WriteLine(separator);

    WriteLine("Message: {0}", e.Message);
}
finally
{
    // We can close and dispose objects here
    Console.ResetColor();
    WriteLine();
    heating.TurnOff();
}
