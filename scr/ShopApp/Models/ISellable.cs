namespace ShopApp.Models;

public interface ISellable
{
    decimal CalculatePrice();
    string GetProductInfo();
}