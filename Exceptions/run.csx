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
    Console.WriteLine("\nHeatingException succeed");
    Console.WriteLine(separator);
    Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine("Class: {0}", e.TargetSite.DeclaringType);
    Console.WriteLine("Type: {0}", e.TargetSite.MemberType);
    Console.WriteLine("Method: {0}", e.TargetSite);
    Console.WriteLine("Source: {0}", e.Source);
    Console.WriteLine("Stack: {0}", e.StackTrace);
    Console.WriteLine("Help link: {0}", e.HelpLink);

    Console.WriteLine("Message: {0}", e.Message);
    Console.WriteLine("Time: {0}", e.Time);
    Console.WriteLine("Reason: {0}", e.Reason);

    if (e.Data != null)
    {
        foreach (DictionaryEntry item in e.Data)
        {
            Console.WriteLine("{0} {1}", item.Key, item.Value);
        }
    }
}
catch (ArgumentException e)
{
    Console.WriteLine("\nArgument Exception succeed");
    Console.WriteLine(separator);

    Console.WriteLine("Message: {0}", e.Message);
}
catch (Exception e) when (e.GetType() != typeof(FormatException))
{
    Console.WriteLine("\nException (Not FormatException) succeed");
    Console.WriteLine(separator);

    Console.WriteLine("Message: {0}", e.Message);
}
catch (Exception e)
{
    Console.WriteLine("\nException succeed");
    Console.WriteLine(separator);

    Console.WriteLine("Message: {0}", e.Message);
}
finally
{
    // We can close and dispose objects here
    Console.ResetColor();
    Console.WriteLine();
    heating.TurnOff();
}
