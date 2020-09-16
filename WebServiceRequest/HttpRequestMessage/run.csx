#load "data.csx"

#r "nuget: System.Net.Http.Json, 3.2.0"

var weatherData = new WeatherData();
await weatherData.FetchData().ConfigureAwait(false);

WriteLine("Weather Data:");

if (!string.IsNullOrWhiteSpace(weatherData.Error))
{
    WriteLine(weatherData.Error);
}
else if (weatherData.Forecast is null)
{
    WriteLine("Loading...");
}
else
{
    WriteLine(weatherData.Forecast);
}
