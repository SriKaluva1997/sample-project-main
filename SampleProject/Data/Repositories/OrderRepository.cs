using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
        void Delete(Order order);
        Order GetById(Guid id);
        IEnumerable<Order> GetAll();
    }

    public class OrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            var existing = GetById(order.Id);
            if (existing != null)
            {
                InMemoryDatabase.Orders.Remove(existing);
            }

            InMemoryDatabase.Orders.Add(order);
        }

        public void Delete(Order order)
        {
            InMemoryDatabase.Orders.RemoveAll(o => o.Id == order.Id);
        }

        public Order GetById(Guid id)
        {
            return InMemoryDatabase.Orders.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return InMemoryDatabase.Orders;
        }
    }
}
