using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrandTravel.Angular.Views
{
    [AllowAnonymous]
    public class PackageDetailsController : Controller
    {
        // GET: PackageDetails
        public ActionResult Index()
        {
            return View();
        }
    }
}