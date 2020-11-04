using System.Diagnostics.CodeAnalysis;

var list = new List<int>();

for (var i = 0; i < 10000000; i++)
    list.Add(i);

// Count() > 0
var s1 = Stopwatch.StartNew();
[SuppressMessage("csharp", "RCS1077", Justification = "Performance test")]
var r1 = list.Count() > 0;
s1.Stop();

// Count > 0
var s2 = Stopwatch.StartNew();
var r2 = list.Count > 0;
s2.Stop();

// Any()
var s3 = Stopwatch.StartNew();
[SuppressMessage("csharp", "RCS1080", Justification = "Performance test")]
var r3 = list.Any();
s3.Stop();

Console.WriteLine($"Count() = {s1.Elapsed.TotalMilliseconds}");
Console.WriteLine($"Count = {s2.Elapsed.TotalMilliseconds}");
Console.WriteLine($"Any() = {s3.Elapsed.TotalMilliseconds}");
