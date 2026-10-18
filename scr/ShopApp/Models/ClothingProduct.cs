namespace ShopApp.Models;

public class ClothingProduct : Product, ISellable
{
    public string Size { get; set; } = string.Empty;

    public override decimal CalculatePrice()
    {
        return BasePrice;
    }

    public string GetProductInfo()
    {
        return $"[Одяг] {Name}, Розмір: {Size}, Ціна: {CalculatePrice():F2} грн.";
    }

    public override void DisplayInfo()
    {
        Console.WriteLine(GetProductInfo());
    }
}
