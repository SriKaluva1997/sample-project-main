using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IProductRepository
    {
        void Save(Product product);
        void Delete(Product product);
        Product GetById(Guid id);
        IEnumerable<Product> GetAll();
    }

    public class ProductRepository : IProductRepository
    {
        public void Save(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
                InMemoryDatabase.Products.Remove(existing);

            InMemoryDatabase.Products.Add(product);
        }

        public void Delete(Product product)
        {
            InMemoryDatabase.Products.RemoveAll(p => p.Id == product.Id);
        }

        public Product GetById(Guid id)
        {
            return InMemoryDatabase.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return InMemoryDatabase.Products;
        }
    }
}

