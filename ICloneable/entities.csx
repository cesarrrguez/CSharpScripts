public class Student : ICloneable
{
    public string Name { get; private set; }
    public double Average { get; private set; }

    public Student(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

        Name = name;
    }

    public void SetAverage(double average)
    {
        if (average < 0) throw new ArgumentException(nameof(average));

        Average = average;
    }

    public override string ToString()
    {
        return $"Student. Name: {Name}, Average: {Average}";
    }

    public object Clone()
    {
        var temp = new Student(Name);
        temp.SetAverage(Average);

        return temp;
    }
}
