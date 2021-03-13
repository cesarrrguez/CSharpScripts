#load "entities.csx"

var sales = new List<Sale>()
{
    new Sale() { Product = "Beer", Amount = 100, Brand = "Corona" },
    new Sale() { Product = "Beer", Amount = 200, Brand = "Corona" },
    new Sale() { Product = "Beer", Amount = 300, Brand = "Guinness" },
    new Sale() { Product = "Water", Amount = 10, Brand = "Mineral" },
    new Sale() { Product = "Water", Amount = 20, Brand = "Natural" },
    new Sale() { Product = "Water", Amount = 30, Brand = "Natural" }
};

var totalSales = from s in sales
                 group s by new
                 {
                     s.Product,
                     s.Brand
                 } into totals
                 select new
                 {
                     totals.Key.Product,
                     totals.Key.Brand,
                     Total = totals.Sum(x => x.Amount),
                     Quantity = totals.Count(),
                     Average = totals.Average(x => x.Amount),
                     Min = totals.Min(x => x.Amount),
                     Max = totals.Max(x => x.Amount)
                 };

foreach (var total in totalSales)
{
    WriteLine($"{total.Product} {total.Brand} {total.Total} {total.Quantity} {total.Average} {total.Min} {total.Max}");
}
