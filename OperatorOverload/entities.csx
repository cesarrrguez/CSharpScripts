public class MyObject
{
    public int Property1 { get; set; }
    public int Property2 { get; set; }
    public int Property3 { get; set; }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public static bool operator ==(MyObject obj1, MyObject obj2)
    {
        return obj1?.Property1 == obj2?.Property1 && obj1?.Property2 == obj2?.Property2 && obj1?.Property3 == obj2?.Property3;
    }

    public static bool operator !=(MyObject obj1, MyObject obj2)
    {
        return obj1?.Property1 != obj2?.Property1 || obj1?.Property2 != obj2?.Property2 || obj1?.Property3 != obj2?.Property3;
    }
}
