public class Beer
{
    public string Name { get; private set; }
    public string Style { get; private set; }

    public Beer SetName(string name)
    {
        Name = name;
        return this;
    }

    public Beer SetStyle(string style)
    {
        Style = style;
        return this;
    }

    public override string ToString()
    {
        return $"{GetType().Name}. {nameof(Name)}: {Name}, {nameof(Style)}: {Style}";
    }
}
