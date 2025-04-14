using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        Order Get(Guid id);
        IEnumerable<Order> GetAll(Guid? productId = null);
    }
}
