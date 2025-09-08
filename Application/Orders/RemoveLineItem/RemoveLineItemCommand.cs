using Domain.Orders;

namespace Application.Orders.RemoveLineItem;

public record RemoveLineItemCommand(OrderId OrderId, LineItemId LineItemId);
