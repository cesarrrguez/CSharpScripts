#load "no.csx"
#load "yes.csx"

// No
var duck = new Duck();
var rubberDuck = new RubberDuck();

duck.Fly();

try
{
    rubberDuck.Fly();
}
catch (NotSupportedException e)
{
    WriteLine(e);
}

// Yes
var duck_LSP = new Duck_LSP();
var rubberDuck_LSP = new RubberDuck_LSP();

duck_LSP.Fly();
