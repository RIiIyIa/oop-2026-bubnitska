using ShopApp.Models;

ShopManager shop = new ShopManager();

// Заповнення каталогу товарами
shop.AddToCatalog(new ElectronicsProduct { Id = 1, Name = "Смартфон", Category = "Електроніка", BasePrice = 19999.99m, WarrantyMonths = 12 });
shop.AddToCatalog(new ElectronicsProduct { Id = 2, Name = "Навушники", Category = "Електроніка", BasePrice = 2500.00m, WarrantyMonths = 6 });
shop.AddToCatalog(new FoodProduct { Id = 3, Name = "Кава зернова", Category = "Продукти", BasePrice = 350.00m, ExpirationDate = new DateTime(2027, 10, 15) });
shop.AddToCatalog(new FoodProduct { Id = 4, Name = "Шоколад", Category = "Продукти", BasePrice = 90.00m, ExpirationDate = new DateTime(2026, 12, 1) });

// 1. Фільтрація та сортування
Console.WriteLine("--- Фільтрація та сортування (Електроніка дешевша за 25000 грн) ---");
var filteredProducts = shop.FilterAndSortProducts("Електроніка", 25000m);

// Демонстрація матеріалізації запиту за допомогою ToList() (негайне виконання)
var materializedList = filteredProducts.ToList(); 

foreach (var product in materializedList)
{
    product.DisplayInfo();
}

// 2. Проєктування даних (Select)
Console.WriteLine("\n--- Проєктування даних (Select) ---");
foreach (var item in shop.GetProductProjections())
{
    Console.WriteLine(item);
}

// 3. Групування та агрегування (GroupBy)
shop.DisplayCategorySummary();
