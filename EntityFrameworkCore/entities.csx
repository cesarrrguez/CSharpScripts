public interface IAggregateRoot { }

public class Entity
{
    public int Id { get; protected set; }
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

    // Empty constructor for EF
    protected User() { }

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

    public void AddAddress(int id, string street, string city, string state, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException(nameof(street));
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city));
        if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
        if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentNullException(nameof(zipCode));

        var address = new UserAddress(this, id, street, city, state, zipCode);

        _addresses.Add(address);
    }

    public void AddEmail(int id, string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentNullException(nameof(emailAddress));

        var email = new UserEmail(this, id, emailAddress);

        _emails.Add(email);
    }
}

public class UserAddress : Entity
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public User User { get; private set; }

    // Empty constructor for EF
    protected UserAddress() { }

    public UserAddress(User user, int id, string street, string city, string state, string zipCode)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException(nameof(street));
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city));
        if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
        if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentNullException(nameof(zipCode));

        User = user;
        Id = id;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }
}

public class UserEmail : Entity
{
    public string EmailAddress { get; private set; }
    public User User { get; private set; }

    // Empty constructor for EF
    protected UserEmail() { }

    public UserEmail(User user, int id, string emailAddress)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentNullException(nameof(emailAddress));

        User = user;
        Id = id;
        EmailAddress = emailAddress;
    }
}
