using GrandTravel.Entity;
using GrandTravel.Entity.Enums;
using GrandTravel.Managers;
using GrandTravel.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Tafe.CourseList.Angular.Controllers
{


   
    public class AccountController : Controller
    {
        private CustomerManager _accountManager;

        public AccountController()
        {
            _accountManager = new CustomerManager(new EfCustomerRepo());
        }

        // GET: CustomerAccount
        public ActionResult Index()
        {
            Claim sessionEmail = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Email);
            string userEmail = sessionEmail.Value;
            var userAccount = _accountManager.getByEmail(userEmail);
            if(userAccount != null)
            {
                return View(userAccount);
            }
            else
            {
                Customer customer = new Customer();
                return View(customer);
            }
            
        }
    }
}