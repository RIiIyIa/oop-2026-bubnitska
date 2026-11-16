namespace ShopApp.Models;

public sealed class StockChangedEventArgs : EventArgs
{
    public int OldQuantity { get; }
    public int NewQuantity { get; }

    public StockChangedEventArgs(int oldQuantity, int newQuantity)
        => (OldQuantity, NewQuantity) = (oldQuantity, newQuantity);
}