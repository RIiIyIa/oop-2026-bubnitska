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
                throw new ArgumentException("Назва товару не може бути порожньою.", nameof(value));
            _name = value;
        }
    }

    public string Category
    {
        get => _category;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Категорія не може бути порожньою.", nameof(value));
            _category = value;
        }
    }

    public decimal BasePrice
    {
        get => _basePrice;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Ціна не може бути від'ємною.");
            _basePrice = value;
        }
    }

    public int Quantity => _quantity;

    // Подія зміни залишку товару (зберігаємо з 8-ї лабораторної)
    public event EventHandler<StockChangedEventArgs>? StockChanged;

    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity < 0)
            throw new ArgumentOutOfRangeException(nameof(newQuantity), "Кількість не може бути від'ємною.");

        int previous = _quantity;
        _quantity = newQuantity;

        StockChanged?.Invoke(this, new StockChangedEventArgs(previous, newQuantity));
    }

    public void AddProduct(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Кількість для додавання має бути більшою за 0.");
        
        UpdateQuantity(_quantity + amount);
    }

    // Безпечне списання з перевіркою залишку (інваріант стану)
    public void RemoveProduct(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Кількість для списання має бути більшою за 0.");

        if (amount > _quantity)
        {
            // Стан залишається повністю незмінним, викидаємо власний виняток
            throw new InsufficientStockException(_name, amount, _quantity);
        }

        UpdateQuantity(_quantity - amount);
    }

    public abstract decimal CalculatePrice();

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"[ID: {Id}] Товар: {_name}, Ціна: {_basePrice} грн., Залишок: {_quantity} шт.");
    }
}
