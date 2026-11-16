namespace ShopApp.Models;

public sealed class ShopNotifier
{
    // Обробник події зміни залишку товару
    public void HandleStockChanged(object? sender, StockChangedEventArgs e)
    {
        if (sender is Product product)
        {
            Console.WriteLine($"[Сповіщення] У товару '{product.Name}' змінено залишок: {e.OldQuantity} -> {e.NewQuantity} шт.");
            
            if (e.NewQuantity < 3)
            {
                Console.WriteLine($"[УВАГА] Критично низький залишок товару '{product.Name}'! Потрібно поповнити склад.");
            }
        }
    }

    // Підписка на подію товару
    public static void Subscribe(Product product, ShopNotifier notifier)
    {
        product.StockChanged += notifier.HandleStockChanged;
    }

    // Підзадача 1: Добір товарів за допомогою Predicate<Product>
    public static List<Product> FilterProducts(IEnumerable<Product> products, Predicate<Product> condition)
    {
        return products.Where(p => condition(p)).ToList();
    }
}