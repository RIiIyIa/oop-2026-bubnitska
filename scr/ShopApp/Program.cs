using ShopApp.Models;

// 1. Створення товарів
ElectronicsProduct phone = new ElectronicsProduct
{
    Id = 1,
    Name = "Смартфон",
    Category = "Електроніка",
    BasePrice = 19999.99m,
    WarrantyMonths = 12
};

FoodProduct coffee = new FoodProduct
{
    Id = 2,
    Name = "Кава зернова",
    Category = "Продукти",
    BasePrice = 350.00m,
    ExpirationDate = new DateTime(2027, 10, 15)
};

// 2. Налаштування підписки на подію StockChanged
ShopNotifier notifier = new ShopNotifier();
ShopNotifier.Subscribe(phone, notifier);

phone.UpdateQuantity(10); // Звичайне поповнення

// Викличе попередження про низький залишок (< 3)
phone.UpdateQuantity(2); 

// 3. Використання Predicate<Product> для фільтрації товарів
Console.WriteLine("\n--- Добір товарів за допомогою Predicate<T> ---");
Predicate<Product> affordableProducts = p => p.BasePrice < 1000m;
var cheapItems = ShopNotifier.FilterProducts(new List<Product> { phone, coffee }, affordableProducts);

foreach (var item in cheapItems)
{
    item.DisplayInfo();
}

// 4. Використання лямбда-виразу / Func для обчислення суми замовлення
Func<Order, decimal> calculateOrderTotal = order => order.CalculateTotal();

Customer customer = new Customer { Name = "Олександр Шевченко" };
Order order = new Order(customer);
order.AddItem(phone);
order.AddItem(coffee);

decimal totalSum = calculateOrderTotal(order);
Console.WriteLine($"\nЗагальна сума замовлення (через Func): {totalSum:F2} грн.");
