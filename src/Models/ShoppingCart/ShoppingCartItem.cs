namespace projekt.src.Models.ShoppingCart;

public class ShoppingCartItem
{
    public ShoppingCartItem(){}
    private ShoppingCartItem(Guid id, Guid shoppingCartId, Guid announcementId, Quantity quantity)
    {
        Id = id;
        ShoppingCartId = shoppingCartId;
        AnnouncementId = announcementId;
        Quantity = quantity;
    }

    public Guid Id { get; private set; }
    public Guid ShoppingCartId { get; private set; }
    public Guid AnnouncementId { get; private set; }
    public Quantity Quantity { get; private set; }

    public static ShoppingCartItem NewItem(Guid shoppingCartId, Guid announcementId, Quantity quantity)
    {
        return new ShoppingCartItem(Guid.NewGuid(), shoppingCartId, announcementId, quantity);
    }

    public void Update(Quantity quantity)
    {
        Quantity = quantity;
    }
}
