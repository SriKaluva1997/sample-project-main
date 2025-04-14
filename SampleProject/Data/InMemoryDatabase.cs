using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public static class InMemoryDatabase
    {
        public static List<Product> Products { get; } = new List<Product>();
        public static List<Order> Orders { get; } = new List<Order>();
    }
}
