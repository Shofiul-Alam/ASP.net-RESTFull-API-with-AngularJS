using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using GrandTravel.Repo;

namespace GrandTravel.Managers
{
    public class CustomerManager
    {
        private IRepository<Customer> _customerRepo;
        private EfCustomerRepo _efCustomerRepo;
    

        public CustomerManager(IRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
            _efCustomerRepo = new EfCustomerRepo();
        }


        public Customer Create(Customer customer)
        {
            return _customerRepo.Create(customer);
        }

        public bool Delete(Customer customer)
        {
            return _customerRepo.Delete(customer);
        }

        public IList<Customer> GetAll()
        {
            return _customerRepo.GetAll();
        }

        public Customer GetById(long id)
        {
            return _customerRepo.GetById(id);
        }

        public Customer Update(Customer customer)
        {
            return _customerRepo.Update(customer);
        }
        public IQueryable<Customer> Query(System.Linq.Expressions.Expression<Func<Customer, bool>> filter)
        {
            return _customerRepo.Query(filter);
        }
        public Customer getByEmail(string email)
        {
            return _efCustomerRepo.getByEmail(email);
        }

    }
}
