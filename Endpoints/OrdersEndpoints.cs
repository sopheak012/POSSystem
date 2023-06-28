using POSSystem.Repositories;

namespace POSSystem.Entities;

public static class OrdersEndpoints
{
    const string GetOrderEndpointName = "GetOrder";
    public static RouteGroupBuilder MapOrdersEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/orders");

        group.MapGet("/", (IOrdersRepository repository) =>
        {
            var sortedOrders = repository.GetAll().OrderByDescending(order => order.TimeStamp).ToList();
            return Results.Ok(sortedOrders);
        }).WithName(GetOrderEndpointName);

        group.MapGet("/{orderNum}", (IOrdersRepository repository, int orderNum) =>
        {
            Order? order = repository.Get(orderNum);
            return order is null ? Results.NotFound("Order is not found") : Results.Ok(order);
        });

        group.MapPost("/", (IOrdersRepository repository, Order newOrder) =>
        {
            repository.Create(newOrder);
            return Results.CreatedAtRoute(GetOrderEndpointName, new { orderNum = newOrder.OrderNum }, newOrder);
        });


        group.MapPut("/{updateOrderNum}", (IOrdersRepository repository, int updateOrderNum, Order updateOrder) =>
        {
            Order? existingOrder = repository.Get(updateOrderNum);

            if (existingOrder is null)
            {
                return Results.NotFound("Order not found");
            }
            repository.Update(updateOrder, updateOrderNum);
            return Results.Ok("Order updated");
        });


        group.MapDelete("/{deleteOrderNum}", (IOrdersRepository repository, int deleteOrderNum) =>
        {
            Order? order = repository.Get(deleteOrderNum);
            if (order is null)
            {
                return Results.NotFound($"Order with number {deleteOrderNum} not found");
            }
            repository.Delete(deleteOrderNum);
            return Results.Ok($"Order with number {deleteOrderNum} has been successfully deleted");
        });

        return group;

    }
}