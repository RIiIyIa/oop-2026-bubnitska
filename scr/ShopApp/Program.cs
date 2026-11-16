using ShopApp.Models;

ElectronicsProduct phone = new ElectronicsProduct
{
    Id = 1,
    Name = "Смартфон",
    Category = "Електроніка",
    BasePrice = 19999.99m,
    WarrantyMonths = 12
};

phone.AddProduct(5); // Додаємо 5 шт. на склад

bool isProcessing = true;

// Сценарій 1: Спроба списати більшу кількість, ніж є на складі (викликає InsufficientStockException)
try
{
    Console.WriteLine("Спроба списати 10 шт. смартфона...");
    phone.RemoveProduct(10);
}
catch (InsufficientStockException ex)
{
    Console.WriteLine($"[Помилка складу]: {ex.Message}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[Помилка аргументу]: {ex.Message}");
}
finally
{
   isProcessing = false;
    Console.WriteLine($"Стан обробки (isProcessing): {isProcessing}");
    Console.WriteLine($"Операція завершена. Поточний залишок не змінився і становить: {phone.Quantity} шт.\n");
}

// Сценарій 2: Перевірка валідації вхідних даних (ArgumentOutOfRangeException)
try
{
    Console.WriteLine("Спроба встановити ціну...");
    phone.BasePrice = -500m;
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[Перехоплено виняток валідації]: {ex.ParamName} -> {ex.Message}");
}
