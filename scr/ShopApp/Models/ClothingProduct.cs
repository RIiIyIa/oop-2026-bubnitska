namespace ShopApp.Models;

public class ClothingProduct : Product
{
    public string Size { get; set; } = string.Empty; // Розмір одягу

    public override decimal CalculatePrice()
    {
        return BasePrice; 
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"[Одяг] Назва: {Name}, Розмір: {Size}, Ціна: {CalculatePrice():F2} грн.");
    }
}