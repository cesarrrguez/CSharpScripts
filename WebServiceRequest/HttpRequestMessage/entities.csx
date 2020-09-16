using System.Diagnostics.CodeAnalysis;

[SuppressMessage("csharp", "IDE1006", Justification = "Use API nomenclature")]
public class WeatherForecastModel
{
    public List<DayForecastModel> consolidated_weather { get; set; }
    public string title { get; set; }
    public string timezone { get; set; }

    public override string ToString()
    {
        var result = $"{title}, {timezone}\n";

        result += "\nDate \t\tWeather State \tLow \tHigh";
        result += "\n----------\t-------------\t------\t------";
        consolidated_weather.Reverse();
        foreach (var item in consolidated_weather)
        {
            result += $"\n{item.applicable_date,-3}\t";
            result += $"{item.weather_state_name,-12}\t";
            result += $"{Math.Round(item.min_temp, 3),-2}\t";
            result += $"{Math.Round(item.max_temp, 3),-3}";
        }

        return result;
    }
}

[SuppressMessage("csharp", "IDE1006", Justification = "Use API nomenclature")]
public class DayForecastModel
{
    public string weather_state_name { get; set; }
    public string applicable_date { get; set; }
    public double min_temp { get; set; }
    public double max_temp { get; set; }
}
