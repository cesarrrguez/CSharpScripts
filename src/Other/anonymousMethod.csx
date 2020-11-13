var user = new User();

// Create anonymous method
user.Message += () => WriteLine("Writting from anonymous method");

// Invoke anonymous method
user.Message();

// Create anonymous method again
user.Message += () => WriteLine("Writting from another anonymous method");

WriteLine();

// Invoke anonymous method 2
user.Message();

// User class
public class User
{
    public delegate void MessageDelegate();
    public MessageDelegate Message;
}
