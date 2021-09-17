#load "entities.csx"

var numbers = new List<int>() { 2, 4, 1, 4, 22, 12, 6, 12 };
var numbers2 = numbers.Where(x => x > 2).OrderBy(x => x).Take(5).ToList();
numbers2.ForEach(x => WriteLine(x));

WriteLine();

var sb = new StringBuilder();
sb.Append("Hello").Append(" ").Append("World").Replace("World", "Spain");
WriteLine(sb.ToString());

WriteLine();

var beer = new Beer();
beer.SetName("Mahou").SetStyle("Classic");
WriteLine(beer);
