using GrandTravel.Angular.Library;
using GrandTravel.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrandTravel.Angular.Controllers
{
    public class PayPalPaymentController : Controller
    {
        // GET: PayPalPayment
        public ActionResult Index()
        {
            PackageView PaypalOrder = new PackageView();


             PaypalOrder = HttpContext.Session["PayPalPayment"] as PackageView;


            if(PaypalOrder != null)
            {
                return View(PaypalOrder);
            }
            else
            {
                return null;
            }

            
        }
    }
}