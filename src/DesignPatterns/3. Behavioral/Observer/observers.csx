#load "interfaces.csx"

// Concrete Observer
public class ConsoleObserver : IObserver
{
    public void Update(SubjectEvent subjectEvent)
    {
        WriteLine("An event just happened!");
        WriteLine($"Event type: {subjectEvent.EventType}");
        WriteLine($"Date: {subjectEvent.EventDate}");
    }
}
