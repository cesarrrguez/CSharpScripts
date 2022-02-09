var stopwatch = new Stopwatch();
var loopNumber = 10000;
var text = "text";
var stringText = string.Empty;

stopwatch.Start();
for (var i = 0; i < loopNumber; i++)
{
    stringText += text;
}
stopwatch.Stop();
WriteLine($"String elapsed time: {stopwatch.ElapsedMilliseconds} ms");

StringBuilder stringBuilder = new StringBuilder();
stopwatch.Restart();
for (var i = 0; i < loopNumber; i++)
{
    stringBuilder.Append(text);
}
stopwatch.Stop();
WriteLine($"String Builder elapsed time: {stopwatch.ElapsedMilliseconds} ms");
