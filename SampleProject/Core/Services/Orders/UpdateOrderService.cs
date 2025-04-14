using System;
using BusinessEntities;
using Common;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void Update(Order order, Guid productId, int quantity, DateTime orderDate)
        {
            order.SetProductId(productId);
            order.SetQuantity(quantity);
            order.SetOrderDate(orderDate);
        }
    }
}
