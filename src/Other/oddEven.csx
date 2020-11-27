var query = "A446-5488844 9.19 A446-5488877 6.63 A449-5488844 9.19 A449-5488877 6.63 A488-5488844 9.19 A488-5488877 6.63 A690-3488844 9.61";

var resultOdd = query.Split(' ').Where((_, i) => i % 2 == 0);
var resultEven = query.Split(' ').Where((_, i) => i % 2 != 0);

WriteLine($"Odd: {string.Join(", ", resultOdd)}\n");
WriteLine($"Even: {string.Join(", ", resultEven)}");
