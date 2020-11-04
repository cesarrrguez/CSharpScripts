var stopwatch = new Stopwatch();
var loopNumber = 10000;
var text = "text";
var stringText = string.Empty;

stopwatch.Start();
for (var i = 0; i < loopNumber; i++)
    stringText += text;
stopwatch.Stop();
Console.WriteLine($"String took {stopwatch.ElapsedMilliseconds} milliseconds.");

StringBuilder stringBuilder = new StringBuilder();
stopwatch.Restart();
for (var i = 0; i < loopNumber; i++)
    stringBuilder.Append(text);
stopwatch.Stop();
Console.WriteLine($"String Builder took {stopwatch.ElapsedMilliseconds} milliseconds.");
