decimal total = 1000;
decimal discount;
decimal tax;

public interface IOperation
{
    void Operation(decimal total, ref decimal tax, ref decimal discount);
}

public class Operation1 : IOperation
{
    public void Operation(decimal total, ref decimal tax, ref decimal discount) => tax = total * 0.2m;
}

public class Operation2 : IOperation
{
    public void Operation(decimal total, ref decimal tax, ref decimal discount) => tax = total * 0.1m;
}

public class Operation3 : IOperation
{
    public void Operation(decimal total, ref decimal tax, ref decimal discount) => discount = total * 0.2m;
}

public class Operation4 : IOperation
{
    public void Operation(decimal total, ref decimal tax, ref decimal discount) => discount = total * 0.3m;
}

var actions = new Dictionary<Predicate<decimal>, IOperation>
{
    { t => t < 10, new Operation1() },
    { t => t >= 10 && t < 100, new Operation2() },
    { t => t >= 100 && t < 1000, new Operation3() },
    { t => t >= 1000, new Operation4() }
};

var operation = actions.ToList().Find(d => d.Key(total)).Value;
operation.Operation(total, ref tax, ref discount);

WriteLine(total + tax - discount); // 700
