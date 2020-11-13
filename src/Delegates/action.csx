// Action
// -----------------------------------------------------------
// Is a generic delegate type.
// An Action type delegate is the same as Func delegate except 
// that the Action delegate doesn't return a value.
// -----------------------------------------------------------

var action = new Action<string, int>(RepeatMessage);
var text = "Hello world";
var times = 5;

// Call action
action(text, times);

public static void RepeatMessage(string message, int times)
{
    for (int i = 0; i < times; i++)
        WriteLine(message);
}
