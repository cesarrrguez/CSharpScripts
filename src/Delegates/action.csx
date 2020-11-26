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
