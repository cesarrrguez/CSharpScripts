string s1 = "duck";
object s2 = new string("duck");

string s3 = "duCK";

WriteLine($" == {s1 == (string)s2}");
WriteLine($"Equals {s1.Equals(s2)}");
WriteLine($"Equals IC {s1.Equals(s3, StringComparison.OrdinalIgnoreCase)}");
WriteLine($"Compare {String.Compare(s1, s3) == 0}");
