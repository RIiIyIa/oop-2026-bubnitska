namespace ShopApp.Models;

public abstract class Product
{
    private string _name = string.Empty;
    private string _category = string.Empty;
    private decimal _basePrice;
    private int _quantity;

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Помилка: Назва товару не може бути порожньою!");
                return;
            }
            _name = value;
        }
    }

    public string Category
    {
        get => _category;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Помилка: Категорія товару не може бути порожньою!");
                return;
            }
            _category = value;
        }
    }

    public decimal BasePrice
    {
        get => _basePrice;
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Помилка: Ціна товару не може бути від'ємною!");
                return;
            }
            _basePrice = value;
        }
    }

    public int Quantity => _quantity;

    public void AddProduct(int amount)
    {
        if (amount > 0) _quantity += amount;
    }

    public void RemoveProduct(int amount)
    {
        if (amount > 0 && amount <= _quantity) _quantity -= amount;
    }

    // Віртуальний або абстрактний метод для поліморфізму
    public abstract decimal CalculatePrice();

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Товар: {_name}, Категорія: {_category}, Базова ціна: {_basePrice} грн., Кількість: {_quantity} шт.");
    }
}
