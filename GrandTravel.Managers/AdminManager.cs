using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using GrandTravel.Repo;

namespace GrandTravel.Managers
{
    public class AdminManager
    {
        private IRepository<Administrator> _adminRepo;

        public AdminManager(IRepository<Administrator> adminRepo)
        {
            _adminRepo = adminRepo;
        }
        public Administrator Create(Administrator admin)
        {
            return _adminRepo.Create(admin);
        }

        public bool Delete(Administrator admin)
        {
            return _adminRepo.Delete(admin);
        }

        public IList<Administrator> GetAll()
        {
            return _adminRepo.GetAll();
        }

        public Administrator GetById(long id)
        {
            return _adminRepo.GetById(id);
        }

        public Administrator Update(Administrator admin)
        {
            return _adminRepo.Update(admin);
        }
    }
}
