using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using GrandTravel.Repo;

namespace GrandTravel.Managers
{
    public class OrderManager
    {
        private IRepository<Order> _orderRepo;

        public OrderManager(IRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public Order Create(Order order)
        {
            return _orderRepo.Create(order);
        }

        public bool Delete(Order order)
        {
            return _orderRepo.Delete(order);
        }

        public IList<Order> GetAll()
        {
            return _orderRepo.GetAll();
        }

        public Order GetById(long id)
        {
            return _orderRepo.GetById(id);
        }

        public Order Update(Order order)
        {
            return _orderRepo.Update(order);
        }
    }
}
