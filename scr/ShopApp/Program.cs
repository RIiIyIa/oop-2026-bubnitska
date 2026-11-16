using ShopApp.Models;

// 1. Створення об'єкта record Snapshot
ProductSnapshot phone = new ProductSnapshot(
    Id: 1,
    Name: "Смартфон",
    BasePrice: 19999.99m,
    Category: "Електроніка",
    Description: "Флагманський смартфон із потужним процесором"
);

PriceValue priceStruct = new PriceValue(19999.99m);

Console.WriteLine($"Товар: {phone.Name} | Ціна (struct): {priceStruct.Value} грн.");
Console.WriteLine($"Цінова категорія: {ProductDataProcessor.GetPriceCategory(phone)}");
Console.WriteLine($"Опис: {ProductDataProcessor.GetDescriptionText(phone)}");

// 2. Демонстрація роботи з діапазонами для SKU
string sampleSku = "ELK-98765";
Console.WriteLine($"Префікс SKU ({sampleSku}): {ProductDataProcessor.GetSkuPrefix(sampleSku)}");

// 3. Демонстрація незмінності та виразу with (створення копії зі зміненою ціною)
var discountedPhone = ProductDataProcessor.WithNewPrice(phone, 17999.99m);
Console.WriteLine($"Знижка! Нова ціна смартфона: {discountedPhone.BasePrice} грн.");
