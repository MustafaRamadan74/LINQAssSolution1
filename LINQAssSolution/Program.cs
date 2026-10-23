using LINQ.DataSources;

namespace LINQAssSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var seafood = Source.ProductList.Where(p => p.Category == "Seafood");
            foreach (var p in seafood)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:F2}");

            // =====

            var names = Source.ProductList.Select(p => p.ProductName).ToList();
            foreach (var name in names)
                Console.WriteLine(name);

            // =====

            var byPrice = Source.ProductList.OrderBy(p => p.UnitPrice);
            foreach (var p in byPrice)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:F2}");

            // =====

            var midPriced = Source.ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            foreach (var p in midPriced)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:F2}");

            // =====

            var inStockCondiments = Source.ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Spices & Condiments");
            foreach (var p in inStockCondiments)
                Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");

            // =====

            var stockInfo = Source.ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var item in stockInfo)
                Console.WriteLine(item);

            // =====

            var numbered = Source.ProductList.Select((p, i) => $"{i + 1}. {p.ProductName}");
            foreach (var line in numbered)
                Console.WriteLine(line);

            // =====

            var sorted = Source.ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var p in sorted)
                Console.WriteLine($"{p.Category} | {p.ProductName} | {p.UnitPrice:F2}");

            // =====

            var beverages = Source.ProductList
                .Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);
            foreach (var p in beverages)
                Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");

            // =====

            var recentOrders = from c in Source.CustomerList
                               from o in c.Orders
                               where o.OrderDate.Year >= 1997
                               select new { c.CustomerID, o.OrderDate };
            foreach (var item in recentOrders)
                Console.WriteLine($"{item.CustomerID} - {item.OrderDate:yyyy-MM-dd}");

            // =====

            var withPosition = Source.ProductList.Select((p, i) => new { Position = i + 1, p.ProductName });
            foreach (var item in withPosition)
                Console.WriteLine($"{item.Position} - {item.ProductName}");

            // =====

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedWords = Arr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in sortedWords)
                Console.WriteLine(w);

            // =====

            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var secondLetterI = digits.Where(d => d[1] == 'i').Reverse().ToList();
            foreach (var d in secondLetterI)
                Console.WriteLine(d);
        }
    }
}
