#load "../../packages.csx"

#load "enums.csx"

using System.Globalization;

using Humanizer;
using Humanizer.Localisation;

var spanishCulture = new CultureInfo("es-ES");

var strings = new Func<string>[]
{
    // General stuff
    () => "user_not_found", // user_not_found
    () => "user_not_found".Humanize(), // user not found
    () => "user_not_found".Humanize(LetterCasing.Sentence), // User not found
    () => "HTML".Humanize(), // HTML
    () => "user_not_found_HTML".Humanize(), // user not found HTML
    () => "User not found".Dehumanize(), // UserNotFound
    () => "User not found".Underscore(), // user_not_found
    () => "This is the story of my life".Truncate(14, "..."), // This is the...
    () => ExampleEnum.FirstValue.Humanize(), // First value
    () => ExampleEnum.SecondValue.Humanize(), // This is the second value
    () => "person".Pluralize(), // people

    // Dates
    () => DateTime.UtcNow.AddHours(-24).Humanize(), // yesterday
    () => DateTime.UtcNow.AddHours(-36).Humanize(), // 2 days ago
    () => DateTime.UtcNow.AddMinutes(-36).Humanize(), // 36 minutes ago
    () => DateTime.UtcNow.AddMinutes(69).Humanize(), // an hour from now

    // TimeSpans
    () => TimeSpan.FromMilliseconds(252000).Humanize(2), // 4 minutes, 12 seconds
    () => TimeSpan.FromDays(7).Humanize(maxUnit: TimeUnit.Day), // 7 days

    // Case stuff
    () => "César Rodríguez".Pascalize(), // CésarRodríguez
    () => "César Rodríguez".Camelize(), // césarRodríguez
    () => "César Rodríguez".Underscore(), // césar_rodríguez
    () => "César Rodríguez".Dasherize(), // César Rodríguez
    () => "César Rodríguez".Hyphenate(), // César Rodríguez
    () => "César Rodríguez".Kebaberize(), // césar-rodríguez

    // Numbers
    () => 1.ToWords(), // one
    () => 1.ToOrdinalWords(), // first
    () => 69.Millions().ToString(), // 69000000
    () => 420.Gigabytes().ToFullWords(), // 420 gigabytes
    () => 420.Gigabytes().ToString(), // 420 GB

    // Culture
    () => 1.ToWords(spanishCulture) // uno
};

foreach (var textFunc in strings)
{
    WriteLine(textFunc());
}
