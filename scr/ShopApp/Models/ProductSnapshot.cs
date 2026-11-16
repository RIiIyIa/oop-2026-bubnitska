namespace ShopApp.Models;

public sealed record ProductSnapshot(
    int Id, 
    string Name, 
    decimal BasePrice, 
    string Category, 
    string? Description);

public readonly record struct PriceValue(decimal Value);

public static class ProductDataProcessor
{
    // 1. Класифікація товару за ціною та залишком через switch-expression (Pattern Matching)
    public static string GetPriceCategory(ProductSnapshot product) =>
        product.BasePrice switch
        {
            >= 15000m => "Преміум",
            >= 5000m => "Середній",
            >= 1000m => "Бюджетний",
            _ => "Доступний"
        };

    // 2. Безпечне опрацювання nullable reference types для необов'язкових характеристик
    public static string GetDescriptionText(ProductSnapshot product) =>
        product.Description is { Length: > 0 } desc
            ? desc
            : "Опис відсутній";

    // 3. Використання діапазонів для обробки коду SKU (або назви категорії)
    public static string GetSkuPrefix(string skuCode) =>
        skuCode.Length >= 3 ? skuCode[..3] : skuCode;

    // 4. Використання виразу with для створення копії з оновленою ціною
    public static ProductSnapshot WithNewPrice(ProductSnapshot product, decimal newPrice) =>
        product with { BasePrice = newPrice };
}