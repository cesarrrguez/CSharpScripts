#load "interfaces.csx"

// Terminal Expression 1
public class DayExpression : IExpression
{
    public void Evaluate(Context context)
    {
        context.Expression = context.Expression.Replace("DD", context.Date.Day.ToString());
    }
}

// Terminal Expression 2
public class MonthExpression : IExpression
{
    public void Evaluate(Context context)
    {
        context.Expression = context.Expression.Replace("MM", context.Date.Month.ToString());
    }
}

// Terminal Expression 3
public class YearExpression : IExpression
{
    public void Evaluate(Context context)
    {
        context.Expression = context.Expression.Replace("YYYY", context.Date.Year.ToString());
    }
}

// Terminal Expression 4
class SeparatorExpression : IExpression
{
    public void Evaluate(Context context)
    {
        context.Expression = context.Expression.Replace(" ", "-");
    }
}
