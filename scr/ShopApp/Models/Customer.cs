namespace ShopApp.Models;

public class Customer
{
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Помилка: Ім'я покупця не може бути порожнім!");
                return;
            }
            _name = value;
        }
    }
}
