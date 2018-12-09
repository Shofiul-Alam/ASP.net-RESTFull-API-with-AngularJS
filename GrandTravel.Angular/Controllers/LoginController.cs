using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrandTravel.Angular.Models;
using GrandTravel.Repo;
using GrandTravel.Managers;
using System.Security.Claims;
using GrandTravel.CustomLibraries;
using GrandTravel.Entity.Enums;
using System.Collections.Generic;
using GrandTravel.Entity;

namespace GrandTravel.Angular.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private CustomerManager _customerManager;

        public LoginController()
        {
            _customerManager = new CustomerManager(new EfCustomerRepo());
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
   

            if (!ModelState.IsValid) //Checks if input fields have the correct format
            {
                return View(model); //Returns the view with the input values so that the user doesn't have to retype again
            }





                var user = _customerManager.getByEmail(model.Email);

            if (user != null) { 
                var decryptedPassword = CustomDecrypt.Decrypt(user.Password, user.Salt);
            
                
            /*
                var materializePassword = getPassword.ToList();
                var password = Convert.ToString(materializePassword[0]);
                var decryptedPassword = CustomDecrypt.Decrypt(password);*/

            if (model.Email != null && model.Password == decryptedPassword)
                {
                    var name = user.FirstName + " " + user.LastName;
                    var surename = user.FirstName;
                    var email= user.Email;
                    RoleEnum userRoleIndex = user.Authorization;
                    var role = userRoleIndex.ToString();
                    string userId = Convert.ToString(user.CustomerId);


                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Surname, surename),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.Sid, userId)

                },
                        "ApplicationCookie");

                    var ctx = Request.GetOwinContext();
                    var authManager = ctx.Authentication;

                    authManager.SignIn(identity);


                    return RedirectToAction("Index", "Home");
                }
            }



            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }


    }
}