public class SubjectEvent
{
    public string EventType { get; }
    public DateTime EventDate { get; }

    public SubjectEvent(string eventType, DateTime eventDate)
    {
        EventType = eventType ?? throw new ArgumentNullException(nameof(eventType));
        EventDate = eventDate;
    }
}
