using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Get(Guid id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetAll(string name = null)
        {
            return _productRepository.GetAll()
                .Where(p => string.IsNullOrWhiteSpace(name) || IsMatch(p.Name, name));
        }

        private bool IsMatch(string source, string target)
        {
            if (string.IsNullOrWhiteSpace(source))
                return false;

            return source?.IndexOf(target ?? "", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
