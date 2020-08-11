using System.Runtime.Serialization;

[Serializable]
public class HeatingException : ApplicationException
{
    public string Reason { get; private set; }
    public DateTime Time { get; private set; }

    public HeatingException() { }
    public HeatingException(string message) : base(message) { }
    public HeatingException(string message, Exception inner) : base(message, inner) { }
    protected HeatingException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    public HeatingException(string message, string reason, DateTime time) : base(message)
    {
        Reason = reason;
        Time = time;
    }
}
