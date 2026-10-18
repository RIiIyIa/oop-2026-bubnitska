namespace ShopApp.Models;

public class ElectronicsProduct : Product, ISellable
{
    public int WarrantyMonths { get; set; } // Гарантія в місяцях

    // Перевизначення розрахунку ціни (наприклад, з урахуванням податку на електроніку)
    public override decimal CalculatePrice()
    {
        return BasePrice * 1.05m; // +5% податок
    }

    public string GetProductInfo()
    {
        return $"[Електроніка] {Name}, Ціна: {CalculatePrice():F2} грн., Гарантія: {WarrantyMonths} міс.";
    }

    public override void DisplayInfo()
    {
        Console.WriteLine(GetProductInfo());
    }
}
