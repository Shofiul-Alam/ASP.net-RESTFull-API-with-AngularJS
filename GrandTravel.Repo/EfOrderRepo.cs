using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using System.Data.Entity;

namespace GrandTravel.Repo
{
    public interface IOrderRepo : IRepository<Order>
    {
    }

    public class EfOrderRepo : BaseEFRepository<Order>, IOrderRepo
    {
        private GrandTravelContext _context;
        private DbSet<Order> _dbSet;

        public EfOrderRepo()
        {
            _context = new GrandTravelContext();
            _dbSet = _context.Set<Order>();
        }
        public long getLastOrderId()
        {
            var last = _dbSet.Where(c => c.OrderId == _dbSet.Max(x => x.OrderId));
            if (last.Count() > 0)
            {
                var lastOrder = last.Single();
                long lastOrderId = lastOrder.OrderId;
                return lastOrderId;
            }
            else
            {
                return 0;
            }
        }
    }
}
