using ShopApp.Models;

Customer customer1 = new()
{
    Name = "Олександр Шевченко"
};

Customer customer2 = new()
{
    Name = "Марія Бондаренко"
};

Product product1 = new()
{
    Name = "Смартфон",
    Price = 19999.99m,
    Category = "Електроніка"
};

Product product2 = new()
{
    Name = "Кавоварка",
    Price = 4500.00m,
    Category = "Побутова техніка"
};

Console.WriteLine("Покупці:");
Console.WriteLine($"- {customer1.Name}");
Console.WriteLine($"- {customer2.Name}");

Console.WriteLine("\nТовари:");
Console.WriteLine($"{product1.Name} ({product1.Category}) – {product1.Price} грн.");
Console.WriteLine($"{product2.Name} ({product2.Category}) – {product2.Price} грн.");