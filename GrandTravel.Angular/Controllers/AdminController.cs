using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GrandTravel.Entity;
using GrandTravel.Managers;
using GrandTravel.Repo;
using GrandTravel.CustomLibraries;

namespace GrandTravel.Angular.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        private AdminManager _adminManager;
        private CustomerManager _customerManager;
        private EfCustomerRepo _customer;

        public AdminController()
        {
            _adminManager = new AdminManager(new EfAdminRepo());
            _customerManager = new CustomerManager(new EfCustomerRepo());
            _customer = new EfCustomerRepo();
        }

        [HttpGet,Route("")]
        public Administrator GetAdmin()
        {
            long id = 1;
            return _adminManager.GetById(id);
        }

        [HttpPost,Route("")]
        public Administrator Create(Administrator admin)
        {
            return _adminManager.Create(admin);
        }

        [HttpGet,Route("{id}")]
        public Administrator GetById(long id)
        {
            return _adminManager.GetById(id);
        }
        [HttpGet, Route("customer/edit/{HashId}")]
        public Customer EditCustomer(string HashId)
        {
            var user = _customer.getBySecureId(HashId);
           
            if(user != null)
            {
                long id = Convert.ToInt32(user.CustomerId);
                return _customerManager.GetById(id);
            }
            else
            {
                Customer customer = new Customer();
                return customer;
            }
            

        }

        

        [HttpDelete, Route("{id}")]
        public bool Delete(long id)
        {
            var admin = _adminManager.GetById(id);

            return _adminManager.Delete(admin);
        }

        [HttpPut,Route("{id}")]
        public Administrator Update(long id, Administrator admin)
        {
            admin.AdminId = id;

            return _adminManager.Update(admin);
        }
    }
}
