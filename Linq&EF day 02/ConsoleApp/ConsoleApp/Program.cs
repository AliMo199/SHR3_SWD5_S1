using day10_G01;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        #region Restriction Operators
        Console.WriteLine("Restriction Operators:");
        var outOfStock = ListGenerators.ProductList
            .Where(p => p.UnitsInStock == 0);
        Console.WriteLine("\nOut of Stock Products:");
        foreach (var p in outOfStock) Console.WriteLine(p);

        var inStockExpensive = ListGenerators.ProductList
            .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);
        Console.WriteLine("\nIn Stock and Price > 3:");
        foreach (var p in inStockExpensive) Console.WriteLine(p);

        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var shorterNames = digits
            .Select((name, index) => new { name, index })
            .Where(x => x.name.Length < x.index);
        Console.WriteLine("\nDigits shorter than their value:");
        foreach (var d in shorterNames) Console.WriteLine($"{d.name} ({d.index})");
        #endregion
        #region Element Operators
        Console.WriteLine("\n\nElement Operators:");
        var firstOutOfStock = ListGenerators.ProductList
            .FirstOrDefault(p => p.UnitsInStock == 0);
        Console.WriteLine($"First Out Of Stock: {firstOutOfStock}");

        var expensiveProduct = ListGenerators.ProductList
            .FirstOrDefault(p => p.UnitPrice > 1000);
        Console.WriteLine($"First Product Price > 1000: {expensiveProduct}");

        int[] arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var secondGreaterThanFive = arr.Where(n => n > 5).Skip(1).FirstOrDefault();
        Console.WriteLine($"Second number > 5: {secondGreaterThanFive}");
        #endregion
        #region Aggregate Operators
        Console.WriteLine("\n\nAggregate Operators:");
        int oddCount = arr.Count(n => n % 2 != 0);
        Console.WriteLine($"Odd Numbers Count: {oddCount}");

        var customerOrders = ListGenerators.CustomerList
            .Select(c => new { c.Name, OrderCount = c.Orders.Count() });
        Console.WriteLine("\nCustomers and Order Count:");
        foreach (var c in customerOrders) Console.WriteLine($"{c.Name} - {c.OrderCount}");

        var categoryCounts = ListGenerators.ProductList
            .GroupBy(p => p.Category)
            .Select(g => new { Category = g.Key, Count = g.Count() });
        Console.WriteLine("\nProducts per Category:");
        foreach (var c in categoryCounts) Console.WriteLine($"{c.Category}: {c.Count}");

        int sum = arr.Sum();
        Console.WriteLine($"\nSum of Array: {sum}");

        var stockByCategory = ListGenerators.ProductList
            .GroupBy(p => p.Category)
            .Select(g => new { Category = g.Key, TotalStock = g.Sum(p => p.UnitsInStock) });
        Console.WriteLine("\nTotal Units in Stock by Category:");
        foreach (var s in stockByCategory) Console.WriteLine($"{s.Category}: {s.TotalStock}");

        var cheapestProducts = from p in ListGenerators.ProductList
                               group p by p.Category into g
                               let minPrice = g.Min(p => p.UnitPrice)
                               from p in g
                               where p.UnitPrice == minPrice
                               select p;
        Console.WriteLine("\nCheapest Product(s) per Category:");
        foreach (var p in cheapestProducts) Console.WriteLine(p);

        var expensiveProducts = from p in ListGenerators.ProductList
                                group p by p.Category into g
                                let maxPrice = g.Max(p => p.UnitPrice)
                                from p in g
                                where p.UnitPrice == maxPrice
                                select p;
        Console.WriteLine("\nMost Expensive Product(s) per Category:");
        foreach (var p in expensiveProducts) Console.WriteLine(p);

        var avgPrice = ListGenerators.ProductList
            .GroupBy(p => p.Category)
            .Select(g => new { Category = g.Key, AvgPrice = g.Average(p => p.UnitPrice) });
        Console.WriteLine("\nAverage Price per Category:");
        foreach (var c in avgPrice) Console.WriteLine($"{c.Category}: {c.AvgPrice}");
        #endregion
        #region Ordering Operators
        Console.WriteLine("\n\nOrdering Operators:");
        var productsByName = ListGenerators.ProductList.OrderBy(p => p.ProductName);
        Console.WriteLine("Products Sorted by Name:");
        foreach (var p in productsByName) Console.WriteLine(p.ProductName);

        string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        var caseInsensitiveSort = words.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("\nCase-Insensitive Word Sort:");
        foreach (var w in caseInsensitiveSort) Console.WriteLine(w);

        var stockDesc = ListGenerators.ProductList.OrderByDescending(p => p.UnitsInStock);
        Console.WriteLine("\nProducts Sorted by Stock (Desc):");
        foreach (var p in stockDesc.Take(5)) Console.WriteLine(p);

        var sortedDigits = digits.OrderBy(d => d.Length).ThenBy(d => d);
        Console.WriteLine("\nDigits Sorted by Length then Alphabetical:");
        foreach (var d in sortedDigits) Console.WriteLine(d);

        var categoryPrice = ListGenerators.ProductList
            .OrderBy(p => p.Category)
            .ThenByDescending(p => p.UnitPrice);
        Console.WriteLine("\nProducts Sorted by Category then Price Desc:");
        foreach (var p in categoryPrice.Take(10)) Console.WriteLine(p);
        #endregion
        #region Transformation Operators
        Console.WriteLine("\n\nTransformation Operators:");
        var productNames = ListGenerators.ProductList.Select(p => p.ProductName);
        Console.WriteLine("Product Names:");
        foreach (var name in productNames.Take(10)) Console.WriteLine(name);

        string[] words2 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
        var upperLower = words2.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
        Console.WriteLine("\nWords Upper & Lower:");
        foreach (var wl in upperLower) Console.WriteLine($"{wl.Upper} / {wl.Lower}");

        var productProjection = ListGenerators.ProductList
            .Select(p => new { p.ProductName, Price = p.UnitPrice });
        Console.WriteLine("\nProduct Projection (Name + Price):");
        foreach (var p in productProjection.Take(5)) Console.WriteLine($"{p.ProductName} - {p.Price}");

        var matchIndex = arr.Select((n, i) => new { Number = n, InPlace = (n == i) });
        Console.WriteLine("\nArray Numbers and In-Place Check:");
        foreach (var m in matchIndex) Console.WriteLine($"{m.Number}: {m.InPlace}");

        var cheapOrders = ListGenerators.CustomerList
            .SelectMany(c => c.Orders)
            .Where(o => o.Total < 500);
        Console.WriteLine("\nOrders < 500:");
        foreach (var o in cheapOrders) Console.WriteLine(o);

        var recentOrders = ListGenerators.CustomerList
            .SelectMany(c => c.Orders)
            .Where(o => o.OrderDate.Year >= 1998);
        Console.WriteLine("\nOrders from 1998+ :");
        foreach (var o in recentOrders) Console.WriteLine(o);
        #endregion
        #region Partitioning Operators
        Console.WriteLine("\n\nPartitioning Operators:");
        var first3OrdersWA = ListGenerators.CustomerList
            .Where(c => c.City == "Washington")
            .SelectMany(c => c.Orders)
            .Take(3);
        Console.WriteLine("First 3 Orders from Washington:");
        foreach (var o in first3OrdersWA) Console.WriteLine(o);

        var skip2OrdersWA = ListGenerators.CustomerList
            .Where(c => c.City == "Washington")
            .SelectMany(c => c.Orders)
            .Skip(2);
        Console.WriteLine("\nAll but First 2 Orders from Washington:");
        foreach (var o in skip2OrdersWA) Console.WriteLine(o);

        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var takeWhileExample = numbers.TakeWhile((n, index) => n >= index);
        Console.WriteLine("\nNumbers Until Less Than Index:");
        foreach (var n in takeWhileExample) Console.WriteLine(n);

        var skipUntilDiv3 = numbers.SkipWhile(n => n % 3 != 0);
        Console.WriteLine("\nNumbers from First Divisible by 3:");
        foreach (var n in skipUntilDiv3) Console.WriteLine(n);

        var skipUntilLessThanIndex = numbers.SkipWhile((n, index) => n >= index);
        Console.WriteLine("\nNumbers from First Less Than Index:");
        foreach (var n in skipUntilLessThanIndex) Console.WriteLine(n);
        #endregion
        #region Quantifier Operators
        Console.WriteLine("\n\nQuantifier Operators:");
        var categoriesWithOutOfStock = ListGenerators.ProductList
            .GroupBy(p => p.Category)
            .Where(g => g.Any(p => p.UnitsInStock == 0));
        Console.WriteLine("\nCategories with Out of Stock Products:");
        foreach (var g in categoriesWithOutOfStock) Console.WriteLine(g.Key);

        var categoriesAllInStock = ListGenerators.ProductList
            .GroupBy(p => p.Category)
            .Where(g => g.All(p => p.UnitsInStock > 0));
        Console.WriteLine("\nCategories with All In Stock:");
        foreach (var g in categoriesAllInStock) Console.WriteLine(g.Key);
        #endregion
    }
}

