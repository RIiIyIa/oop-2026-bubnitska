namespace ShopApp.Models;

public class FoodProduct : Product, ISellable
{
    public DateTime ExpirationDate { get; set; } // Термін придатності

    public override decimal CalculatePrice()
    {
        return BasePrice; // Продукти без додаткового податку
    }

    public string GetProductInfo()
    {
        return $"[Продукти] {Name}, Ціна: {CalculatePrice():F2} грн., Придатний до: {ExpirationDate.ToShortDateString()}";
    }

    public override void DisplayInfo()
    {
        Console.WriteLine(GetProductInfo());
    }
}
