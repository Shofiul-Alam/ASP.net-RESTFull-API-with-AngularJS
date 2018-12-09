using System;
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


namespace GrandTravel.Angular.Controllers
{

    [RoutePrefix("api/travelProvider")]
    public class TravelProviderController : ApiController
    {
        
        private TravelProviderManager _travelProviderManager;
        private EfTravelProviderRepo _travelProvider;


        public TravelProviderController()
        {
            _travelProviderManager = new TravelProviderManager(new EfTravelProviderRepo());
            _travelProvider = new EfTravelProviderRepo();
        }
      

        [HttpGet,Route("")]
        public TravelProvider GetUser()
        {
            Claim sessionEmail = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Sid);
            long customerId = Convert.ToInt32(sessionEmail.Value);
            var user = _travelProviderManager.Query(u => u.CustomerId == customerId).First();
            return user; 
        }
        [Authorize(Roles = "Customer")]
        [HttpPost,Route("")]
        public TravelProvider Create(TravelProvider travelProvider)
        {
            Claim sessionCId = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Sid);
            string Cid = sessionCId.Value;
            travelProvider.CustomerId = Convert.ToInt32(Cid);
            travelProvider.JoinDate = DateTime.Now;

        

/*
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {

                    var fileName = image.FileName;

                    var savedFileName = Path.Combine(HttpContext.Current.Server.MapPath("~/images/Customer/images/"), fileName);
                    image.SaveAs(savedFileName);
                    customer.Image = fileName;

                }

             }*/

            return _travelProviderManager.Create(travelProvider);
        }
          

        [HttpGet,Route("{id}")]
        public TravelProvider GetById(long id)
        {
            return _travelProviderManager.GetById(id);
        }

        [HttpDelete, Route("{id}")]
        public bool Delete(long id)
        {
            var travelProvider = _travelProviderManager.GetById(id);

            return _travelProviderManager.Delete(travelProvider);
        }

        [HttpPut,Route("{id}")]
        public TravelProvider Update(long id, TravelProvider travelProvider)
        {
            travelProvider.TravelProviderId= id;

            return _travelProviderManager.Update(travelProvider);
        }
    }
}
