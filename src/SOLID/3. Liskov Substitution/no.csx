public class Duck
{
    public virtual void Fly() => WriteLine("Fly");
    public virtual void Swim() => WriteLine("Swim");
    public virtual void Cuack() => WriteLine("Cuack");
}

public class RubberDuck : Duck
{
    public override void Fly() => throw new NotSupportedException();
}
