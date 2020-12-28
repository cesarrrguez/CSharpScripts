#load "entities.csx"

// Expression: 1 + 2 + 3
var expression = new Sum(new Sum(new Number(1), new Number(2)), new Number(3));

// Visitor
var visitor = new ExpressionVisitor();
expression.Accept(visitor);
