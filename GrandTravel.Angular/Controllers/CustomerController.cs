using System.Linq;
using System.Web.Http;
using GrandTravel.Entity;
using GrandTravel.Managers;
using GrandTravel.Repo;
using System.Security.Claims;
using System.Web;
using GrandTravel.CustomLibraries;
using System.IO;
using GrandTravel.Entity.Enums;
using System.Collections.Generic;
using System;
using GrandTravel.Angular.Models;
using System.Net.Http;

namespace GrandTravel.Angular.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomerController : ApiController
    {
        StatusEnum status = new StatusEnum();
        private CustomerManager _customerManager;
        private EfCustomerRepo _customer;
        private EfTravelProviderRepo _travelProviderManager;

        public CustomerController()
        {
            _customerManager = new CustomerManager(new EfCustomerRepo());
            _customer = new EfCustomerRepo();
            _travelProviderManager = new EfTravelProviderRepo();
        }

        [HttpGet, Route("")]
        public Customer GetUser()
        {
            Claim sessionEmail = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Email);
            string userEmail = sessionEmail.Value;
            var user = _customerManager.getByEmail(userEmail);
            if(user != null)
            {
                return user;
            }
            else
            {
                Customer customer = new Customer();
                return customer;
            }
            
        }

        [HttpGet,Route("allCustomer")]
        public IList<Customer> GetAll()
        {
            var customers = _customerManager.GetAll();

            for(var i =0; i< customers.Count(); i++)
            {
                var travelProvider = _travelProviderManager.getByCustomerId(customers[i].CustomerId);

                if(travelProvider != null && customers[i].Authorization == RoleEnum.Customer)
                {
                    customers[i].Status = status.Applied_For_TravelProvider;
                }
            }

            return customers;
        }



        [HttpPost, Route("login")]

        public IHttpActionResult login(LoginModel customerLogin)
        {

            var user = _customerManager.getByEmail(customerLogin.Email);

            if (user != null)
            {
                var decryptedPassword = CustomDecrypt.Decrypt(user.Password, user.Salt);


                /*
                    var materializePassword = getPassword.ToList();
                    var password = Convert.ToString(materializePassword[0]);
                    var decryptedPassword = CustomDecrypt.Decrypt(password);*/

                if (customerLogin.Email != null && customerLogin.Password == decryptedPassword)
                {
                    var name = user.FirstName + " " + user.LastName;
                    var surename = user.FirstName;
                    var email = user.Email;
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


                    return Ok();
                }
            }

            ModelState.AddModelError("", "Invalid email or password");
            return Ok();
        }

        [HttpGet, Route("authentication")]

        public string checkAuthentication()
        {
            Claim sessionUserId =  ClaimsPrincipal.Current.FindFirst(ClaimTypes.Sid);
           
            if(sessionUserId != null)
            {
                return "ok";
            }
            else
            {
                return "no";
            }
        }

        [HttpPost,Route("")]
       public Customer Create()
        {

            //Create a customer object
            Customer customer = new Customer();


            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = HttpContext.Current.Server.MapPath("~/uploads/");

            var uploadedFiles = HttpContext.Current.Request.Files;
            HttpPostedFile uploadedFile;

            // CHECK THE FILE COUNT.
            for (int i = 0; i <= uploadedFiles.Count - 1; i++)
            {
                uploadedFile = uploadedFiles[i];
                customer.ImageUrl = "/uploads/" + uploadedFile.FileName;

                if (uploadedFile.ContentLength > 0)
                {

                    string savePath = Path.Combine(sPath, Path.GetFileName(uploadedFile.FileName));
                    // TODO: CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    // SAVE THE FILES IN THE FOLDER.
                    uploadedFile.SaveAs(savePath);

                }
            }

           

            var currentCustomer = HttpContext.Current.Request.Form;

            customer.LoginId = currentCustomer["Customer[LoginId]"];
            customer.Password = currentCustomer["Customer[Password]"];
            customer.Email = currentCustomer["Customer[Email]"];
            customer.FirstName = currentCustomer["Customer[FirstName]"];
            customer.LastName = currentCustomer["Customer[LastName]"];
            customer.DOB = Convert.ToDateTime(currentCustomer["Customer[DOB]"]);
            customer.Address = currentCustomer["Customer[Address]"];

           


            var salt = CustomEnrypt.GenerateSalt();
            customer.Salt = salt;
            var customPasword = CustomEnrypt.Encrypt(customer.Password, customer.Salt);
            customer.Password = customPasword;
            customer.Authorization = RoleEnum.Customer;
            customer.Status = status.Active;

            _customerManager.Create(customer);
            
            var newUser = _customer.getByEmail(customer.Email);
            customer.CustomerId = newUser.CustomerId;
            int customerCurrentId = System.Convert.ToInt32(newUser.CustomerId);
            var secureId = CustomEnrypt.getUniqIdentity(customerCurrentId);
            customer.HashId = secureId;
           

            return _customerManager.Update(customer);
        }
          

        [HttpGet,Route("{HashId}")]
        public Customer GetById(string HashId)
        {
            var user = _customer.getBySecureId(HashId);
            var id = user.CustomerId;
            return _customerManager.GetById(id);
        }



        [HttpGet, Route("delete/{HashId}")]
        public bool Delete(string HashId)
        {
           
            var customer = _customer.getBySecureId(HashId);
            if (customer != null)
            {
                return _customer.deleteBySecureId(customer);
            }
            else
            {
                return true;
            }
                
        }

        [Authorize(Roles ="Customer, Admin, User")]
        [HttpPut,Route("{id}")]
        public IHttpActionResult Update(long id, Customer customer)
        {
             customer.CustomerId = id;
            _customerManager.Update(customer);


            string url = "http://localhost:58121/Account";

            Uri uri = new Uri(url);

            return Redirect(uri);
        }
    }
}
