var user = new User();

// Create anonymous method
user.Message += delegate ()
{
    Console.WriteLine("Writting from anonymous method");
};

// Invoke anonymous method
user.Message();

// Create anonymous method again
user.Message += delegate ()
{
    Console.WriteLine("Writting from another anonymous method");
};

Console.WriteLine();

// Invoke anonymous method 2
user.Message();

// User class
public class User
{
    public delegate void MessageDelegate();
    public MessageDelegate Message;
}
