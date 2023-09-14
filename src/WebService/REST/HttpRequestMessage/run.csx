#load "../../../../packages.csx"

#load "services.csx"

var weatherService = new WeatherService();
await weatherService.FetchDataAsync();

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
