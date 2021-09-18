#load "entities.csx"

#r "nuget: fasterflect, 3.0.0"

using Fasterflect;

var user = GetFakeUser();
WriteLine(user);

SetEmptyUserEmailsWithReflection(user);
WriteLine(user);

user = GetFakeUser();
WriteLine(user);

SetEmptyUserEmailsWithFasterflect(user);
WriteLine(user);

public User GetFakeUser() => new User
{
    Name = "César",
    Emails = new string[] { "cesar1@gmail.com", "cesar2@email.com" }
};

public void SetEmptyUserEmailsWithReflection(object obj)
{
    var propInfo = obj.GetType().GetProperty("Emails");
    if (propInfo == null || propInfo.PropertyType != typeof(string[])) return;

    var setter = propInfo.GetSetMethod();
    if (setter == null) return;

    setter.Invoke(obj, new[] { new string[0] });
}

public void SetEmptyUserEmailsWithFasterflect(object obj)
{
    obj.TrySetPropertyValue("Emails", new string[0]);
}
