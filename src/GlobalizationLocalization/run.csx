#load "utils.csx"

using System.Globalization;

using (new CultureScope(CultureInfo.GetCultureInfo("en-US")))
{
    // Access to resx language key. 
    // For example Translations.PersonalProfileNotFound.
    // ...
}

using (new CultureScope(CultureInfo.GetCultureInfo("es-ES")))
{
    // ...
}
