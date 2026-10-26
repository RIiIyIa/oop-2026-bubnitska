namespace ShopApp.Models;

public class ShopManager
{
    // Dictionary<int, Product> для швидкодійного доступу за ID
    private readonly Dictionary<int, Product> _catalog = new();
    
    // List<Product> для зберігання товарів у кошику
    private readonly List<Product> _cart = new();

    // 1. Додавання товару до каталогу
    public void AddToCatalog(Product product)
    {
        if (!_catalog.ContainsKey(product.Id))
        {
            _catalog.Add(product.Id, product);
        }
    }

    // Видалення товару з каталогу за ID
    public bool RemoveFromCatalog(int id)
    {
        return _catalog.Remove(id);
    }

    // Пошук товару за ID
    public Product? GetProductById(int id)
    {
        _catalog.TryGetValue(id, out var product);
        return product;
    }

    // 2. Додавання товару до кошика
    public void AddToCart(Product product)
    {
        _cart.Add(product);
    }

    public IReadOnlyList<Product> GetCartItems() => _cart.AsReadOnly();

    // 3. Ітератор з yield return для отримання товарів обраної категорії
    public IEnumerable<Product> GetProductsByCategory(string category)
    {
        foreach (var product in _catalog.Values)
        {
            if (product.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            {
                yield return product; // лінива ітерація без створення проміжного списку
            }
        }
    }
}