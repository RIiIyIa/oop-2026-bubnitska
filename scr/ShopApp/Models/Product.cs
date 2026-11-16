namespace ShopApp.Models;

public abstract class Product
{
    public int Id { get; set; }
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

    // Подія зміни залишку товару
    public event EventHandler<StockChangedEventArgs>? StockChanged;

    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity < 0)
        {
            Console.WriteLine("Помилка: Кількість не може бути від'ємною!");
            return;
        }

        int previous = _quantity;
        _quantity = newQuantity;

        StockChanged?.Invoke(this, new StockChangedEventArgs(previous, newQuantity));
    }

    public void AddProduct(int amount)
    {
        if (amount > 0) UpdateQuantity(_quantity + amount);
    }

    public void RemoveProduct(int amount)
    {
        if (amount > 0 && amount <= _quantity) UpdateQuantity(_quantity - amount);
    }

    public abstract decimal CalculatePrice();

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"[ID: {Id}] Товар: {_name}, Категорія: {_category}, Ціна: {_basePrice} грн., Залишок: {_quantity} шт.");
    }
}
