using comp4513_bookstore.Models;

namespace comp4513_bookstore.Services;

public class OrderState
{
    public Order Order { get; set; } = new();
    public event Action OnChange;

    public OrderState()
    {
        Order.OrderItems = new List<OrderItem>();
    }

    public void AddItem(OrderItem item) // add book to cart
    {
        Order.OrderItems.Add(item);
        OnChange?.Invoke();
    }

    public void RemoveItem(OrderItem item) { //remove book from cart
        Order.OrderItems.Remove(item);
    }

    public void ResetOrder() // after placing an order (end of checkout process)
    {
        Order = new Order { OrderItems = new List<OrderItem>() };
        OnChange?.Invoke();
    }
}