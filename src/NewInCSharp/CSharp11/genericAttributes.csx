[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]

// Before C# 11:
// public class TypeAttribute : Attribute
// {
//     public TypeAttribute(Type t) => ParamType = t;

//     public Type ParamType { get; }
// }

// [TypeAttribute(typeof(string))]
// public string Method() => default;

// C# 11 feature:
public class GenericAttribute<T> : Attribute { }

[GenericAttribute<string>]
public string Method() => default;
