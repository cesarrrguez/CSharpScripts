#load "entities.csx"

// Concrete Visitor
public class ExpressionVisitor : IVisitor
{
    public void VisitNumber(Number number) => WriteLine(number.Value);
    public void VisitSum(Sum sum) => WriteLine($"{sum.Left.GetValue()} + {sum.Right.GetValue()} = {sum.GetValue()}");
}
