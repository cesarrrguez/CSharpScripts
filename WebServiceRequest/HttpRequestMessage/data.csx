#load "entities.csx"

using System.Net.Http;
using System.Net.Http.Json;

public class WeatherData
{
    public WeatherForecastModel Forecast { get; set; }
    public string Error { get; set; }
    private readonly HttpClient _client;

    public WeatherData()
    {
        _client = new HttpClient();
    }

    public async Task FetchData()
    {
        const string url = "https://www.metaweather.com/api/location/2487956/";

        var request = new HttpRequestMessage(HttpMethod.Get, url);

        var response = await _client.SendAsync(request).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            Forecast = await response.Content.ReadFromJsonAsync<WeatherForecastModel>().ConfigureAwait(false);
            Error = null;
        }
        else
        {
            Error = $"There was an error getting our forecast {response.ReasonPhrase}";
        }
    }
}