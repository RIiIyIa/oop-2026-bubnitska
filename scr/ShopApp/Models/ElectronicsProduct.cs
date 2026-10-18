namespace ShopApp.Models;

public class ElectronicsProduct : Product
{
    public int WarrantyMonths { get; set; } // Гарантія в місяцях

    // Перевизначення розрахунку ціни (наприклад, з урахуванням податку на електроніку)
    public override decimal CalculatePrice()
    {
        return BasePrice * 1.05m; // +5% податок
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"[Електроніка] Назва: {Name}, Ціна з податком: {CalculatePrice():F2} грн., Гарантія: {WarrantyMonths} міс.");
    }
}