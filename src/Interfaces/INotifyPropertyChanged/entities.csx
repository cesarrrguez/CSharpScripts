using System.ComponentModel;

public class User : INotifyPropertyChanged
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            NotifyPropertyChanged(nameof(Name));
        }
    }

    private int _age;
    public int Age
    {
        get { return _age; }
        set
        {
            _age = value;
            NotifyPropertyChanged(nameof(Age));
        }
    }

    public User(string name, int age)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Age = age;
    }

    protected void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event PropertyChangedEventHandler PropertyChanged;
}
