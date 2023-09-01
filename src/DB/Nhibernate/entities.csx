public interface IAggregateRoot { }

public class Entity
{
    public virtual int Id { get; protected set; }
}

public class User : Entity, IAggregateRoot
{
    public virtual string FirstName { get; }
    public virtual string LastName { get; }
    public virtual int Age { get; }

    private readonly IList<UserAddress> _addresses;
    public virtual IReadOnlyList<UserAddress> Addresses => _addresses.ToList();

    private readonly IList<UserEmail> _emails;
    public virtual IReadOnlyList<UserEmail> Emails => _emails.ToList();

    // Empty constructor for Nhibernate
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

    public virtual void AddAddress(int id, string street, string city, string state, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException(nameof(street));
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city));
        if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
        if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentNullException(nameof(zipCode));

        var address = new UserAddress(this, id, street, city, state, zipCode);

        _addresses.Add(address);
    }

    public virtual void AddEmail(int id, string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentNullException(nameof(emailAddress));

        var email = new UserEmail(this, id, emailAddress);

        _emails.Add(email);
    }
}

public class UserAddress : Entity
{
    public virtual string Street { get; }
    public virtual string City { get; }
    public virtual string State { get; }
    public virtual string ZipCode { get; }
    public virtual User User { get; }

    // Empty constructor for Nhibernate
    protected UserAddress() { }

    public UserAddress(User user, int id, string street, string city, string state, string zipCode)
    {
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
    public virtual string EmailAddress { get; }
    public virtual User User { get; }

    // Empty constructor for Nhibernate
    protected UserEmail() { }

    public UserEmail(User user, int id, string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentNullException(nameof(emailAddress));

        User = user;
        Id = id;
        EmailAddress = emailAddress;
    }
}
