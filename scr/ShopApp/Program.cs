using ShopApp.Models;

// 1. Демонстрація роботи з покупцем
Customer customer = new Customer();
customer.Name = "Олександр Шевченко";
Console.WriteLine($"Покупець: {customer.Name}");

Console.WriteLine("\nСпроба встановити некоректне ім'я покупця:");
customer.Name = ""; // Має вивести помилку

// 2. Демонстрація роботи з товаром та валідацією
Product product = new Product();
product.Name = "Смартфон";
product.Category = "Електроніка";
product.Price = 19999.99m;

Console.WriteLine($"\nТовар: {product.Name}, Категорія: {product.Category}, Ціна: {product.Price} грн.");

Console.WriteLine("\nСпроба встановити некоректну ціну:");
product.Price = -500; // Має вивести помилку

// 3. Демонстрація керування станом товару (додавання та списання)
Console.WriteLine("\n--- Керування кількістю товару ---");
product.AddProduct(10); // Додаємо 10 шт.

Console.WriteLine($"Поточний залишок: {product.Quantity}");

product.RemoveProduct(3); // Списуємо 3 шт.

Console.WriteLine("\nСпроба списати більше товару, ніж є в наявності:");
product.RemoveProduct(15); // Заборонено списання

// Пряма зміна кількості заборонена компілятором:
// product.Quantity = 50; // Помилка компіляції: Property or indexer 'Product.Quantity' cannot be assigned to -- it is read only
