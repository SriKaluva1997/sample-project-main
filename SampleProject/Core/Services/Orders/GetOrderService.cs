using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Get(Guid id)
        {
            return _orderRepository.GetById(id);
        }

        public IEnumerable<Order> GetAll(Guid? productId = null)
        {
            return _orderRepository.GetAll()
                                   .Where(o => !productId.HasValue || o.ProductId == productId.Value);
        }
    }
}
