#load "entities.csx"

public static class UserValidations
{
    public static readonly Predicate<User>[] validations =
    {
        user => GlobalValidations<string>.NotNull(user.FirstName),
        user => GlobalValidations<string>.NotNull(user.FirstName),
        user => user.FirstName.Length < 10,
        user => user.LastName.Length < 50
    };
}

public static class GlobalValidations<T>
{
    public static readonly Predicate<T> NotNull = x => x != null;
}

public static class Validator
{
    public static bool Validate<T>(T data, params Predicate<T>[] validations)
    {
        var isValid = true;

        foreach (var validation in validations.ToList())
        {
            isValid &= validation(data);
            if (!isValid) break;
        }

        return isValid;
    }
}
