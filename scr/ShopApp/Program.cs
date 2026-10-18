using ShopApp.Models;

// 1. Демонстрація роботи з покупцем
Customer customer = new Customer
{
    Name = "Олександр Шевченко"
};
Console.WriteLine($"Покупець: {customer.Name}\n");

// 2. Створення поліморфної колекції товарів різних категорій
List<Product> products = new List<Product>
{
    new ElectronicsProduct
    {
        Name = "Смартфон",
        Category = "Електроніка",
        BasePrice = 19999.99m,
        WarrantyMonths = 12
    },
    new FoodProduct
    {
        Name = "Кава зернова",
        Category = "Продукти",
        BasePrice = 350.00m,
        ExpirationDate = new DateTime(2027, 10, 15)
    },
    new ClothingProduct
    {
        Name = "Куртка зимова",
        Category = "Одяг",
        BasePrice = 2800.00m,
        Size = "L"
    }
};

// 3. Поліморфний виклик методів через посилання на базовий клас Product
Console.WriteLine("Каталог товарів інтернет-магазину (поліморфний вивід):");
foreach (Product product in products)
{
    product.DisplayInfo();
}
