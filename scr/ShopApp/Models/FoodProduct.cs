namespace ShopApp.Models;

public class FoodProduct : Product
{
    public DateTime ExpirationDate { get; set; } // Термін придатності

    public override decimal CalculatePrice()
    {
        return BasePrice; // Продукти без додаткового податку
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"[Продукти] Назва: {Name}, Ціна: {CalculatePrice():F2} грн., Придатний до: {ExpirationDate.ToShortDateString()}");
    }
}