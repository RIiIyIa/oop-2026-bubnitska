namespace ShopApp.Models;

public class ShopManager
{
    private readonly Dictionary<int, Product> _catalog = new();
    private readonly List<Product> _cart = new();

    public void AddToCatalog(Product product)
    {
        if (!_catalog.ContainsKey(product.Id))
        {
            _catalog.Add(product.Id, product);
        }
    }

    public IReadOnlyCollection<Product> GetAllProducts() => _catalog.Values.ToList();

    // 1. Фільтрація та сортування товарів за ціною і категорією
    public IEnumerable<Product> FilterAndSortProducts(string category, decimal maxPrice)
    {
        // Демонстрація відкладеного виконання (deferred execution)
        return _catalog.Values
            .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase) && p.BasePrice <= maxPrice)
            .OrderBy(p => p.BasePrice)
            .ThenBy(p => p.Name);
    }

    // 2. Проєктування даних через Select (анонімні типи або спеціальні проєкції)
    public IEnumerable<object> GetProductProjections()
    {
        return _catalog.Values.Select(p => new
        {
            Title = p.Name,
            Price = p.CalculatePrice(),
            CategoryName = p.Category
        });
    }

    // 3. Групування та агрегування (групування за категоріями)
    public void DisplayCategorySummary()
    {
        var summary = _catalog.Values
            .GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                Count = g.Count(),
                AveragePrice = g.Average(p => p.CalculatePrice())
            });

        Console.WriteLine("\n--- Групування та агрегування за категоріями ---");
        foreach (var group in summary)
        {
            Console.WriteLine($"Категорія: {group.Category} | Кількість товарів: {group.Count} | Середня ціна: {group.AveragePrice:F2} грн.");
        }
    }
}
