using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrandTravel.Angular.Views
{
    [AllowAnonymous]
    public class PackagesController : Controller
    {
        // GET: Packages
        public ActionResult Index()
        {
            return View();
        }
    }
}