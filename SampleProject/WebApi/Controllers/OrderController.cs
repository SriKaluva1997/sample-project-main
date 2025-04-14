using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Orders;
using WebApi.Models.Orders;


namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;

        public OrderController(
            ICreateOrderService createOrderService,
            IUpdateOrderService updateOrderService,
            IDeleteOrderService deleteOrderService,
            IGetOrderService getOrderService)
        {
            _createOrderService = createOrderService;
            _updateOrderService = updateOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage Create(Guid orderId, [FromBody] OrderModel model)
        {
            var order = _createOrderService.Create(orderId, model.ProductId, model.Quantity, model.OrderDate);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage Update(Guid orderId, [FromBody] OrderModel model)
        {
            var order = _getOrderService.Get(orderId);
            if (order == null)
                return DoesNotExist();

            _updateOrderService.Update(order, model.ProductId, model.Quantity, model.OrderDate);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid orderId)
        {
            var order = _getOrderService.Get(orderId);
            if (order == null)
                return DoesNotExist();

            _deleteOrderService.Delete(order);
            return Found();
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetById(Guid orderId)
        {
            var order = _getOrderService.Get(orderId);
            if (order == null)
                return DoesNotExist();

            return Found(new OrderData(order));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetList(Guid? productId = null)
        {
            var orders = _getOrderService.GetAll(productId)
                                         .Select(o => new OrderData(o))
                                         .ToList();
            return Found(orders);
        }
    }
}
