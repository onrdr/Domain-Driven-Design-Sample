using Domain.Customers;

namespace Domain.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = [];
    private Order() { }
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }

    public static Order Create(Customer customer)
    {
        return new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id
        };
    }

    public void Add(Product product)
    {
        var lineItem = new LineItem(Guid.NewGuid(), Id, product.Id, product.Price);

        _lineItems.Add(lineItem);
    }
}

public class LineItem
{
    internal LineItem(Guid id, Guid orderId, Guid productId, Money money) 
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = money;
    }

    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public Money Price { get; private set; }
}