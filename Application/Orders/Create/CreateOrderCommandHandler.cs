using Application.Data;
using Domain.Customers;
using Domain.Orders;
using MediatR;

namespace Application.Orders.Create;

internal sealed class CreateOrderCommandHandler(
    IApplicationDbContext context) : IRequestHandler<CreateOrderCommand>
{
    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await context.Customers.FindAsync([new CustomerId(request.CustomerId)], cancellationToken);

        if (customer is null) { return; }

        var order = Order.Create(customer.Id);

        context.Orders.Add(order);

        await context.SaveChangesAsync(cancellationToken);
    }
}
