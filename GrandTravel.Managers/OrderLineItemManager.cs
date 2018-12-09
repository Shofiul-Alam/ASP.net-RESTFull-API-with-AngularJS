using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using GrandTravel.Repo;

namespace GrandTravel.Managers
{
    public class OrderLineItemManager
    {
        private IRepository<OrderLineItem> _orderLineItemRepo;

        public OrderLineItemManager(IRepository<OrderLineItem> orderLineItemRepo)
        {
            _orderLineItemRepo = orderLineItemRepo;
        }
        public OrderLineItem Create(OrderLineItem orderLineItem)
        {
            return _orderLineItemRepo.Create(orderLineItem);
        }

        public bool Delete(OrderLineItem orderLineItem)
        {
            return _orderLineItemRepo.Delete(orderLineItem);
        }

        public IList<OrderLineItem> GetAll()
        {
            return _orderLineItemRepo.GetAll();
        }

        public OrderLineItem GetById(long id)
        {
            return _orderLineItemRepo.GetById(id);
        }

        public OrderLineItem Update(OrderLineItem orderLineItem)
        {
            return _orderLineItemRepo.Update(orderLineItem);
        }
    }
}
