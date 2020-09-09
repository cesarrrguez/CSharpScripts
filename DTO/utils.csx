// Extensions
// ------------------------------------------------------------

public static string PropertyList(this object obj)
{
    var properties = obj.GetType().GetProperties();
    var sb = new StringBuilder();

    foreach (var property in properties)
    {
        sb.Append(property.Name).Append(": ").Append(property.GetValue(obj, null)).AppendLine();
    }

    return sb.ToString();
}
