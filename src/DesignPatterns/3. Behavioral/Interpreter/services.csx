#load "expressions.csx"

// Client
public class ExpressionService
{
    public void Evaluate(Context context)
    {
        var expressions = new List<IExpression>();

        var inputExpression = context.Expression;

        foreach (var item in context.Expression.Split(' '))
        {
            if (item == "DD")
            {
                expressions.Add(new DayExpression());
            }
            else if (item == "MM")
            {
                expressions.Add(new MonthExpression());
            }
            else if (item == "YYYY")
            {
                expressions.Add(new YearExpression());
            }
        }

        expressions.Add(new SeparatorExpression());

        foreach (var expression in expressions)
        {
            expression.Evaluate(context);
        }

        WriteLine($"{inputExpression}: {context.Expression}");
    }
}
