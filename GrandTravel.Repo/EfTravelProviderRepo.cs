using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using System.Data.Entity;

namespace GrandTravel.Repo
{
    public interface ITravelProviderRepo : IRepository<TravelProvider>
    {
    }

    public class EfTravelProviderRepo : BaseEFRepository<TravelProvider>, ITravelProviderRepo
    {
        private GrandTravelContext _context;
        private DbSet<TravelProvider> _dbSet;


        public EfTravelProviderRepo()
        {
            _context = new GrandTravelContext();
            _dbSet = _context.Set<TravelProvider>();
        }


        public TravelProvider getByCustomerId(long id)
        {
            IEnumerable<TravelProvider> travelProvider = _dbSet.Where(p => p.CustomerId == id);

            if (travelProvider.Count() != 0)
            {
                var user = travelProvider.First();
                return user;
            }
            else
            {
                return null;
            }

        }
    }
}
