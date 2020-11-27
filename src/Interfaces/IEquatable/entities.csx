public class MyObject : IEquatable<MyObject>
{
    public int Property1 { get; set; }
    public int Property2 { get; set; }
    public int Property3 { get; set; }

    public bool Equals(MyObject other) => Property1 == other?.Property1 && Property2 == other?.Property2 && Property3 == other?.Property3;

    public override int GetHashCode() => Property1.GetHashCode() ^ Property2.GetHashCode() ^ Property3.GetHashCode();

    public override string ToString() => $"Property1: {Property1}, Property2: {Property2}, Property3: {Property3}";
}
