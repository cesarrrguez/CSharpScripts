using System.Text.RegularExpressions;

using CSharpFunctionalExtensions;

public sealed class Email
{
    private readonly string _value;

    private Email(string value)
    {
        _value = value;
    }

    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return Result.Failure<Email>("E-mail can't be empty");
        }

        if (email.Length > 100)
        {
            return Result.Failure<Email>("E-mail is too long");
        }

        if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
        {
            return Result.Failure<Email>("E-mail is invalid");
        }

        return Result.Success(new Email(email));
    }

    public static implicit operator string(Email email)
    {
        return email._value;
    }

    public override bool Equals(object obj)
    {
        if (obj is not Email email)
            return false;

        return _value == email._value;
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }
}

public sealed class CustomerName
{
    private readonly string _value;

    private CustomerName(string value)
    {
        _value = value;
    }

    public static Result<CustomerName> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<CustomerName>("Name can't be empty");
        }

        if (name.Length > 50)
        {
            return Result.Failure<CustomerName>("Name is too long");
        }

        return Result.Success(new CustomerName(name));
    }

    public static implicit operator string(CustomerName name)
    {
        return name._value;
    }

    public override bool Equals(object obj)
    {
        if (obj is not CustomerName name)
            return false;

        return _value == name._value;
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }
}

public class Customer
{
    public CustomerName Name { get; private set; }
    public Email Email { get; private set; }

    public Customer(CustomerName name, Email email)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }

    public void ChangeName(CustomerName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void ChangeEmail(Email email)
    {
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }

    public override string ToString()
    {
        return $"{GetType().Name}. {nameof(Name)}: {(string)Name}, {nameof(Email)}: {(string)Email}";
    }
}
