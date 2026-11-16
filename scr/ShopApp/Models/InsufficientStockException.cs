namespace ShopApp.Models;

public sealed class InsufficientStockException : Exception
{
    public InsufficientStockException(string productName, int requested, int available)
        : base($"Недостатньо товару '{productName}' на складі. Замовлено: {requested}, доступно: {available}.") {}
}