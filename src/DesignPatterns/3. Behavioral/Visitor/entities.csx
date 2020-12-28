// Visitor
public interface IVisitor
{
    void VisitNumber(Number number);
    void VisitSum(Sum sum);
}

// Concrete Visitor
public class ExpressionVisitor : IVisitor
{
    public void VisitNumber(Number number) => WriteLine(number.Value);
    public void VisitSum(Sum sum) => WriteLine($"{sum.Left.GetValue()} + {sum.Right.GetValue()} = {sum.GetValue()}");
}

// Element
public abstract class Expression
{
    public abstract void Accept(IVisitor visitor);
    public abstract double GetValue();
}

// Concrete Element A
public class Number : Expression
{
    public double Value { get; set; }

    public Number(double value)
    {
        Value = value;
    }

    public override void Accept(IVisitor visitor) => visitor.VisitNumber(this);
    public override double GetValue() => Value;
}

// Concrete Element B
public class Sum : Expression
{
    public Expression Left { get; set; }
    public Expression Right { get; set; }

    public Sum(Expression left, Expression right)
    {
        Left = left ?? throw new ArgumentNullException(nameof(left));
        Right = right ?? throw new ArgumentNullException(nameof(right));
    }

    public override void Accept(IVisitor visitor) => visitor.VisitSum(this);
    public override double GetValue() => Left.GetValue() + Right.GetValue();
}
