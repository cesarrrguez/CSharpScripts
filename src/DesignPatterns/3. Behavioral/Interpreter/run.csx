#load "services.csx"

var service = new ExpressionService();
Context context = new Context(DateTime.Now);

// MM DD YYYY
context.Expression = "MM DD YYYY";
service.Evaluate(context);

//YYYY MM DD
context.Expression = "YYYY MM DD";
service.Evaluate(context);

// MM DD YYYY
context.Expression = "DD MM YYYY";
service.Evaluate(context);
