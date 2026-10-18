namespace ShopApp.Models;

public class Order
{
    public Customer Customer { get; set; }
    private readonly List<ISellable> _items = new();

    public Order(Customer customer)
    {
        Customer = customer;
    }

    public void AddItem(ISellable item)
    {
        _items.Add(item);
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in _items)
        {
            total += item.CalculatePrice();
        }
        return total;
    }

    public void DisplayOrderDetails()
    {
        Console.WriteLine($"Замовлення для покупця: {Customer.Name}");
        Console.WriteLine("Придбані товари:");
        foreach (var item in _items)
        {
            Console.WriteLine($" - {item.GetProductInfo()}");
        }
        Console.WriteLine($"Загальна сума до сплати: {CalculateTotal():F2} грн.\n");
    }
}