#load "services.csx"

#r "nuget: System.Net.Http.Json, 3.2.0"

var weatherService = new WeatherService();
await weatherService.FetchDataAsync().ConfigureAwait(false);

WriteLine("Weather Data:");

if (!string.IsNullOrWhiteSpace(weatherService.Error))
{
    WriteLine(weatherService.Error);
}
else if (weatherService.Forecast is null)
{
    WriteLine("Loading...");
}
else
{
    WriteLine(weatherService.Forecast);
}

weatherService.Dispose();
