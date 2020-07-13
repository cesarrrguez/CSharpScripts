public interface IAggregateRoot { }

public class Entity
{
    public int Id { get; private set; }
}

public class UserAddress : Entity
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public User User { get; private set; }

    protected UserAddress() { }

    public UserAddress(User user, string street, string city, string state, string zipCode)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException(nameof(street));
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city));
        if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
        if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentNullException(nameof(zipCode));

        User = user;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public override string ToString()
    {
        return $"Address. Street: {Street}, City: {City}, State: {State}, ZipCode: {ZipCode}";
    }
}

public class UserEmail : Entity
{
    public string EmailAddress { get; private set; }
    public User User { get; private set; }

    protected UserEmail() { }

    public UserEmail(User user, string emailAddress)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentNullException(nameof(emailAddress));

        User = user;
        EmailAddress = emailAddress;
    }

    public override string ToString()
    {
        return $"Email. EmailAddress: {EmailAddress}";
    }
}

public class User : Entity, IAggregateRoot
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }

    private readonly List<UserAddress> _addresses;
    public IReadOnlyCollection<UserAddress> Addresses => _addresses;

    private readonly List<UserEmail> _emails;
    public IReadOnlyCollection<UserEmail> Emails => _emails;

    public User(string firstName, string lastName, int age)
    {
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName));
        if (age < 0) throw new ArgumentException(nameof(age));

        FirstName = firstName;
        LastName = lastName;
        Age = age;

        _addresses = new List<UserAddress>();
        _emails = new List<UserEmail>();
    }

    public void AddAddress(string street, string city, string state, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException(nameof(street));
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city));
        if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
        if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentNullException(nameof(zipCode));

        var address = new UserAddress(this, street, city, state, zipCode);

        _addresses.Add(address);
    }

    public void AddEmail(string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentNullException(nameof(emailAddress));

        var email = new UserEmail(this, emailAddress);

        _emails.Add(email);
    }

    public void UpdateAge(int age)
    {
        if (age < 0) throw new ArgumentException(nameof(age));

        Age = age;
    }

    public override string ToString()
    {
        var result = $"User. Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Age: {Age}";

        foreach (var address in _addresses)
        {
            result += $"\n\t{address}";
        }

        foreach (var emailAddress in _emails)
        {
            result += $"\n\t{emailAddress}";
        }

        return result;
    }
}
