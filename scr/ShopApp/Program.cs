using ShopApp.Models;

ShopManager shop = new ShopManager();

// 1. Заповнення каталогу (Dictionary<int, Product>)
shop.AddToCatalog(new ElectronicsProduct
{
    Id = 1,
    Name = "Смартфон",
    Category = "Електроніка",
    BasePrice = 19999.99m,
    WarrantyMonths = 12
});

shop.AddToCatalog(new ElectronicsProduct
{
    Id = 2,
    Name = "Ноутбук",
    Category = "Електроніка",
    BasePrice = 34500.00m,
    WarrantyMonths = 24
});

shop.AddToCatalog(new FoodProduct
{
    Id = 3,
    Name = "Кава зернова",
    Category = "Продукти",
    BasePrice = 350.00m,
    ExpirationDate = new DateTime(2027, 10, 15)
});

// 2. Пошук товару за ID у Dictionary
Console.WriteLine("--- Пошук товару за ID (Dictionary) ---");
var foundProduct = shop.GetProductById(1);
foundProduct?.DisplayInfo();

// 3. Формування кошика (List<Product>)
Console.WriteLine("\n--- Формування кошика (List) ---");
if (foundProduct != null) shop.AddToCart(foundProduct);

foreach (var item in shop.GetCartItems())
{
    Console.WriteLine($"У кошику: {item.Name} - {item.CalculatePrice():F2} грн.");
}

// 4. Отримання товарів категорії 'Електроніка' за допомогою yield return
Console.WriteLine("\n--- Товари категорії 'Електроніка' (yield return) ---");
foreach (Product item in shop.GetProductsByCategory("Електроніка"))
{
    item.DisplayInfo();
}
