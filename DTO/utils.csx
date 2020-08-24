// Extensions
// ------------------------------------------------------------

public static string PropertyList(this object obj)
{
    var properties = obj.GetType().GetProperties();
    var sb = new StringBuilder();

    foreach (var property in properties)
    {
        sb.AppendLine(property.Name + ": " + property.GetValue(obj, null));
    }

    return sb.ToString();
}
