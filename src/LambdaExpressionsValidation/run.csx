#load "validation.csx"

var user = new User { FirstName = "César", LastName = "Rodríguez" };

Action validate = Validator.Validate(user, UserValidations.validations) ? Success : Error;
validate();

public static void Success() => WriteLine("Success");
public static void Error() => WriteLine("Error");
