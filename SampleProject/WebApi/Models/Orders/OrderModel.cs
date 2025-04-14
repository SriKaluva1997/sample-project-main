using System;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
