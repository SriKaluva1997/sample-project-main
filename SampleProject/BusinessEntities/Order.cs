using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private Guid _productId;
        private int _quantity;
        private DateTime _orderDate = DateTime.UtcNow;

        public Guid ProductId
        {
            get => _productId;
            private set => _productId = value;
        }

        public int Quantity
        {
            get => _quantity;
            private set => _quantity = value;
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            private set => _orderDate = value;
        }

        public void SetProductId(Guid productId)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException("ProductId is required.");
            _productId = productId;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0.");
            _quantity = quantity;
        }

        public void SetOrderDate(DateTime orderDate)
        {
            if (orderDate > DateTime.UtcNow)
                throw new ArgumentException("Order date cannot be in the future.");
            _orderDate = orderDate;
        }
    }
}
