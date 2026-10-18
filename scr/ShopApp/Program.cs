using ShopApp.Models;

// 1. Створення каталогу для електроніки за допомогою узагальненого класу Catalog<T>
Catalog<ElectronicsProduct> electronicsCatalog = new Catalog<ElectronicsProduct>();

electronicsCatalog.Add(new ElectronicsProduct
{
    Name = "Смартфон",
    Category = "Електроніка",
    BasePrice = 19999.99m,
    WarrantyMonths = 12
});

electronicsCatalog.Add(new ElectronicsProduct
{
    Name = "Планшет",
    Category = "Електроніка",
    BasePrice = 12500.00m,
    WarrantyMonths = 24
});

Console.WriteLine($"Кількість товарів у каталозі електроніки: {electronicsCatalog.Count}\n");

// 2. Використання узагальненого методу пошуку Find<T>
List<ElectronicsProduct> expensiveProducts = ShopHelper.Find(
    electronicsCatalog.GetAll(),
    p => p.BasePrice > 15000m
);

// 3. Використання узагальненого методу з обмеженням типу DisplayProductNames<T>
Console.WriteLine("Товари вартістю понад 15000 грн:");
ShopHelper.DisplayProductNames(expensiveProducts);
