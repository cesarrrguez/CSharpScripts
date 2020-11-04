// If we try to cast two objects that cannot be cast, we will get System.InvalidCastException.
object number = 6;
string text = (string)number;

// However, if we try to do cast with as operator instead of the exception, we will get null.
object number_2 = 6;
string text_2 = number_2 as string;
