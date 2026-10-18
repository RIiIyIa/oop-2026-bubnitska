using ShopApp.Models;

// 1. Створення покупця
Customer customer = new Customer
{
    Name = "Олександр Шевченко"
};

// 2. Створення товарів
ElectronicsProduct phone = new ElectronicsProduct
{
    Name = "Смартфон",
    Category = "Електроніка",
    BasePrice = 19999.99m,
    WarrantyMonths = 12
};

FoodProduct coffee = new FoodProduct
{
    Name = "Кава зернова",
    Category = "Продукти",
    BasePrice = 350.00m,
    ExpirationDate = new DateTime(2027, 10, 15)
};

ClothingProduct jacket = new ClothingProduct
{
    Name = "Куртка зимова",
    Category = "Одяг",
    BasePrice = 2800.00m,
    Size = "L"
};

// 3. Композиція: створення замовлення та додавання товарів
Order order = new Order(customer);
order.AddItem(phone);
order.AddItem(coffee);
order.AddItem(jacket);

// Виведення інформації про замовлення
order.DisplayOrderDetails();

// 4. Поліморфна робота через інтерфейс ISellable (окремий список товари до продажу)
List<ISellable> sellableItems = new List<ISellable> { phone, coffee, jacket };

Console.WriteLine("Поліморфний розрахунок вартості товарів через інтерфейс ISellable:");
foreach (ISellable item in sellableItems)
{
    Console.WriteLine($"Товар: {item.GetProductInfo()} | Розрахована вартість: {item.CalculatePrice():F2} грн.");
}
