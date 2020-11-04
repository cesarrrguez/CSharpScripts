public class Duck
{
    public virtual void Fly() => Console.WriteLine("Fly");
    public virtual void Swim() => Console.WriteLine("Swim");
    public virtual void Cuack() => Console.WriteLine("Cuack");
}

public class RubberDuck : Duck
{
    public override void Fly()
    {
        throw new NotSupportedException();
    }
}
