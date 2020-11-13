public interface IFly
{
    void Fly();
}

public interface ISwim
{
    void Swim();
}

public interface ICuack
{
    void Cuack();
}

public class Duck_LSP : IFly, ISwim, ICuack
{
    public void Fly() => WriteLine("Fly");
    public void Swim() => WriteLine("Swim");
    public void Cuack() => WriteLine("Cuack");
}

public class RubberDuck_LSP : ISwim, ICuack
{
    public void Swim() => WriteLine("Swim");
    public void Cuack() => WriteLine("Cuack");
}
