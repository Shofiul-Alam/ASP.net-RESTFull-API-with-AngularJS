using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using GrandTravel.Repo;

namespace GrandTravel.Managers
{
    public class TravelProviderManager
    {
        private IRepository<TravelProvider> _travelProviderRepo;

        public TravelProviderManager(IRepository<TravelProvider> travelProviderRepo)
        {
            _travelProviderRepo = travelProviderRepo;
        }
        public TravelProvider Create(TravelProvider travelProvider)
        {
            return _travelProviderRepo.Create(travelProvider);
        }

        public bool Delete(TravelProvider travelProvider)
        {
            return _travelProviderRepo.Delete(travelProvider);
        }

        public IList<TravelProvider> GetAll()
        {
            return _travelProviderRepo.GetAll();
        }

        public TravelProvider GetById(long id)
        {
            return _travelProviderRepo.GetById(id);
        }

        public TravelProvider Update(TravelProvider travelProvider)
        {
            return _travelProviderRepo.Update(travelProvider);
        }
        public IQueryable<TravelProvider> Query(System.Linq.Expressions.Expression<Func<TravelProvider, bool>> filter)
        {
            return _travelProviderRepo.Query(filter);
        }
    }
}
