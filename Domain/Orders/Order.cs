using Domain.Customers;
using Domain.Products;

namespace Domain.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = [];
    private Order() { }
    public OrderId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }

    public static Order Create(CustomerId customerId)
    {
        return new Order
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = customerId
        };
    }

    public void Add(ProductId productId, Money price)
    {
        var lineItem = new LineItem(
            new LineItemId(Guid.NewGuid()), 
            Id, 
            productId, 
            price);

        _lineItems.Add(lineItem);
    }
}
