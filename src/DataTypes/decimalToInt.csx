decimal[] values = { 12.6m, 12.1m, 9.5m, 8.16m, .1m, -.1m, -1.1m, -1.9m, -3.9m };

WriteLine("{0,-8} {1,10} {2,10} {3,15} {4, 10} \n", "Value", "Ceiling", "Floor", "Cast to Int", "ToInt32");

foreach (decimal value in values)
{
    WriteLine("{0,-8} {1,10} {2,10} {3,15} {4,10}", value, Math.Ceiling(value), Math.Floor(value), (int)value, Convert.ToInt32(value));
}
