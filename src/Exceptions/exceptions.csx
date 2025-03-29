using System.Runtime.Serialization;

[Serializable]
public class HeatingException : ApplicationException
{
    public string Reason { get; }
    public DateTime Time { get; }

    public HeatingException() { }
    public HeatingException(string message) : base(message) { }
    public HeatingException(string message, Exception inner) : base(message, inner) { }

    public HeatingException(string message, string reason, DateTime time) : base(message)
    {
        Reason = reason;
        Time = time;
    }
}
