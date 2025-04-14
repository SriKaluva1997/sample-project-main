using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Products;
using WebApi.Models.Products;



namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IUpdateProductService _updateProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IGetProductService _getProductService;

        public ProductController(
            ICreateProductService createProductService,
            IUpdateProductService updateProductService,
            IDeleteProductService deleteProductService,
            IGetProductService getProductService)
        {
            _createProductService = createProductService;
            _updateProductService = updateProductService;
            _deleteProductService = deleteProductService;
            _getProductService = getProductService;
        }

        [Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage Create(Guid productId, [FromBody] ProductModel model)
        {
            var product = _createProductService.Create(productId, model.Name, model.Description, model.Price);
            return Found(new ProductData(product));
        }

        [Route("{productId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage Update(Guid productId, [FromBody] ProductModel model)
        {
            var product = _getProductService.Get(productId);
            if (product == null)
                return DoesNotExist();

            _updateProductService.Update(product, model.Name, model.Description, model.Price);
            return Found(new ProductData(product));
        }

        [Route("{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid productId)
        {
            var product = _getProductService.Get(productId);
            if (product == null)
                return DoesNotExist();

            _deleteProductService.Delete(product);
            return Found();
        }

        [Route("{productId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetById(Guid productId)
        {
            var product = _getProductService.Get(productId);
            if (product == null)
                return DoesNotExist();

            return Found(new ProductData(product));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetList(string name = null)
        {
            var products = _getProductService.GetAll(name)
                                             .Select(p => new ProductData(p))
                                             .ToList();
            return Found(products);
        }
    }
}