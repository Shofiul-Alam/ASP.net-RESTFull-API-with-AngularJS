using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using GrandTravel.Repo;

namespace GrandTravel.Managers
{
    public class PackageManager
    {
        private IRepository<Package> _packageRepo;

        public PackageManager(IRepository<Package> packageRepo)
        {
            _packageRepo = packageRepo;
        }
        public Package Create(Package package)
        {
            return _packageRepo.Create(package);
        }

        public bool Delete(Package package)
        {
            return _packageRepo.Delete(package);
        }

        public IList<Package> GetAll()
        {
            return _packageRepo.GetAll();
        }

        public Package GetById(long id)
        {
            return _packageRepo.GetById(id);
        }

        public Package Update(Package package)
        {
            return _packageRepo.Update(package);
        }
    }
}
