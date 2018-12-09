using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using GrandTravel.Repo;

namespace GrandTravel.Managers
{
    public class LocationManager
    {
        private IRepository<Location> _locationRepo;

        public LocationManager(IRepository<Location> locationRepo)
        {
            _locationRepo = locationRepo;
        }
        public Location Create(Location location)
        {
            return _locationRepo.Create(location);
        }

        public bool Delete(Location location)
        {
            return _locationRepo.Delete(location);
        }

        public IList<Location> GetAll()
        {
            return _locationRepo.GetAll();
        }

        public Location GetById(long id)
        {
            return _locationRepo.GetById(id);
        }

        public Location Update(Location location)
        {
            return _locationRepo.Update(location);
        }
    }
}
