namespace projekt.src.Models.Store;

public class Item
{
    private Item(){}

    private Item(string title, string? description, ItemAmount amount, Cost cost)
    {
        Title = title;
        Description = description;
        Amount = amount;
        Cost = cost;
    }

    public string Title { get; private set; }
    public string? Description { get; private set; }
    public ItemAmount Amount { get; private set; }
    public Cost Cost { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public static Item NewItem(
        string title, string? description, ItemAmount amount, Cost cost)
    {
        return new Item(title, description, amount, cost);
    }

    public void UpdateItem(
        string? title, string? description, ItemAmount? amount, Cost? cost
    )
    {
        Title = title;
        Description = description;
        Amount = amount;
        Cost = cost;
        UpdatedAt = DateTime.UtcNow;
    }

}
