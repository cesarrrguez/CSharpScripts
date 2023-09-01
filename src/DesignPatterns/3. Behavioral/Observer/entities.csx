public class SubjectEvent
{
    public string EventType { get; }
    public DateTime EventDate { get; }

    public SubjectEvent(string eventType, DateTime eventDate)
    {
        EventType = eventType;
        EventDate = eventDate;
    }
}
