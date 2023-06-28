

using POSSystem.Entities;

namespace POSSystem.Repositories;

public interface IOrdersRepository
{
    void Create(Order newOrder);
    void Delete(int deletedOrderNum);
    Order? Get(int orderNum);
    IEnumerable<Order> GetAll();
    void Update(Order updatedOrder, int updateOrderNum);
}
