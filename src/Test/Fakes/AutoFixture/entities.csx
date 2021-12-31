#load "validators.csx"

public class Product
{
    public string Name { get; set; }
    public double Cost { get; set; }
    public bool IsExpensive() => Cost > 999;
}

public class Country
{
    public string Name { get; }

    public Country(string name)
    {
        Name = name;
    }
}

public class User
{
    public string Name { get; }
    public string Password { get; }
    public string Email { get; }
    public Country Country { get; set; }
    public DateTime BornDate { get; set; }

    public Product Product { get; set; }

    public User(string name, string password, string email)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Must be at least one character", nameof(name));

        if (string.IsNullOrEmpty(password) || password.Length < 4 || password.Length > 12)
            throw new ArgumentException("Must be between 4 and 12 characters", nameof(password));

        if (!Validator.EmailIsValid(email))
            throw new ArgumentException("Wrong email address formats", nameof(email));

        Name = name;
        Password = password;
        Email = email;
    }

    public bool IsAdult() =>
        Country?.Name == "ES" &&
        DateTime.Today.Year - BornDate.Year >= 18;
}
