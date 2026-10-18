namespace ShopApp.Models;

public class Product
{
    private string name = string.Empty;
    private string category = string.Empty;
    private decimal price;
    private int quantity;

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Помилка: Назва товару не може бути порожньою!");
                return;
            }
            name = value;
        }
    }

    public string Category
    {
        get => category;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Помилка: Категорія товару не може бути порожньою!");
                return;
            }
            category = value;
        }
    }

    public decimal Price
    {
        get => price;
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Помилка: Ціна не може бути від'ємною!");
                return;
            }
            price = value;
        }
    }

    // Властивість Quantity має приватний setter для захисту від прямої зміни стану
    public int Quantity
    {
        get => quantity;
        private set => quantity = value;
    }

    // Метод додавання товару
    public void AddProduct(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Помилка: Кількість для додавання має бути більшою за 0!");
            return;
        }
        Quantity += amount;
        Console.WriteLine($"Успішно додано {amount} шт. Поточна кількість: {Quantity}");
    }

    // Метод списання товару із забороною списання за недостатньої кількості
    public void RemoveProduct(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Помилка: Кількість для списання має бути більшою за 0!");
            return;
        }

        if (amount > Quantity)
        {
            Console.WriteLine($"Помилка: Недостатньо товару '{Name}' на складі для списання {amount} шт. Доступно: {Quantity}");
            return;
        }

        Quantity -= amount;
        Console.WriteLine($"Успішно списано {amount} шт. Залишок: {Quantity}");
    }
}
