﻿using System;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {
        private readonly IIdObjectFactory<Product> _productFactory;
        private readonly IProductRepository _productRepository;
        private readonly IUpdateProductService _updateProductService;

        public CreateProductService(
            IIdObjectFactory<Product> productFactory,
            IProductRepository productRepository,
            IUpdateProductService updateProductService)
        {
            _productFactory = productFactory;
            _productRepository = productRepository;
            _updateProductService = updateProductService;
        }

        public Product Create(Guid id, string name, string description, decimal price)
        {
            var product = _productFactory.Create(id);
            _updateProductService.Update(product, name, description, price);
            _productRepository.Save(product);
            return product;
        }
    }
}
