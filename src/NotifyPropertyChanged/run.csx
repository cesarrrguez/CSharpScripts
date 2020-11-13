#load "entities.csx"

using System.ComponentModel;

var user = new User("George", 34);
user.PropertyChanged += User_PropertyChanged;

user.Name = "James";
user.Age = 21;

public static void User_PropertyChanged(object sender, PropertyChangedEventArgs e)
{
    var user = (User)sender;
    var value = typeof(User).GetProperty(e.PropertyName).GetValue(user, null);

    WriteLine("Value of property '{0}' was changed! New value is '{1}'", e.PropertyName, value);
}
