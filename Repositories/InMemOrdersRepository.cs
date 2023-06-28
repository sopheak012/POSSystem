

using POSSystem.Entities;

namespace POSSystem.Repositories;

public class InMemOrdersRepository : IOrdersRepository
{
    private readonly List<Order> orders = new List<Order>();

    public IEnumerable<Order> GetAll()
    {
        return orders;
    }

    public Order? Get(int orderNum)
    {
        return orders.Find(order => order.OrderNum == orderNum);

    }

    public void Create(Order newOrder)
    {
        newOrder.OrderNum = (orders.Count == 0) ? 1 : orders.Max(order => order.OrderNum) + 1;
        newOrder.TimeStamp = DateTime.Now;
        orders.Add(newOrder);
    }


    public void Update(Order updatedOrder, int updateOrderNum)
    {
        var index = orders.FindIndex(order => order.OrderNum == updateOrderNum);
        if (index != -1)
        {
            updatedOrder.OrderNum = orders[index].OrderNum; // Keep the original OrderNum
            orders[index] = updatedOrder;
        }
    }
    public void Delete(int deletedOrderNum)
    {
        var index = orders.FindIndex(order => order.OrderNum == deletedOrderNum);
        orders.RemoveAt(index);
    }
}