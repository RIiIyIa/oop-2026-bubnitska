namespace ShopApp.Models;

public static class ShopHelper
{
    // 1. Узагальнений метод пошуку за умовою
    public static List<T> Find<T>(IEnumerable<T> items, Func<T, bool> predicate)
    {
        return items.Where(predicate).ToList();
    }

    // 2. Узагальнений метод з обмеженням типу (працює лише з типом Product та його похідними)
    public static void DisplayProductNames<T>(IEnumerable<T> items) where T : Product
    {
        foreach (T item in items)
        {
            Console.WriteLine($"Назва товару: {item.Name} | Базова ціна: {item.BasePrice} грн.");
        }
    }
}