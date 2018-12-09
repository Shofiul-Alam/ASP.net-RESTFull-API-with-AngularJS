using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GrandTravel.Entity;
using GrandTravel.Managers;
using GrandTravel.Repo;

namespace GrandTravel.Angular.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {
        private OrderManager _orderManager;

        public OrderController()
        {
            _orderManager = new OrderManager(new EfOrderRepo());
        }

        [HttpGet,Route("")]
        public IList<Order> GetAll()
        {
            return _orderManager.GetAll();
        }

        [HttpPost,Route("")]
        public Order Create(Order order)
        {
            return _orderManager.Create(order);
        }

        [HttpGet,Route("{id}")]
        public Order GetById(long id)
        {
            return _orderManager.GetById(id);
        }

        [HttpDelete, Route("{id}")]
        public bool Delete(long id)
        {
            var order = _orderManager.GetById(id);

            return _orderManager.Delete(order);
        }

        [HttpPut,Route("{id}")]
        public Order Update(long id, Order order)
        {
            order.OrderId = id;

            return _orderManager.Update(order);
        }
    }
}
