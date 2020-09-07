string s1 = "duck";
object s2 = new string("duck");

string s3 = "duCK";

Console.WriteLine($" == {s1 == s2}");  // Warning shown
Console.WriteLine($"Equals {s1.Equals(s2)}");
Console.WriteLine($"Equals IC {s1.Equals(s3, StringComparison.OrdinalIgnoreCase)}");
Console.WriteLine($"Compare {String.Compare(s1, s3) == 0}");
