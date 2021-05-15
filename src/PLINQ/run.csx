#load "utils.csx"

var stopwatch = new Stopwatch();
stopwatch.Start();

var numbers = Enumerable.Range(0, 1000);
var filterNumbers = (from n in numbers.AsParallel()
                     where Utils.IsValid(n)
                     select n
).ToList();

WriteLine(stopwatch.ElapsedMilliseconds);
