using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GrandTravel.Entity;
using GrandTravel.Managers;
using GrandTravel.Repo;

namespace GrandTravel.Angular.Controllers
{
    [RoutePrefix("api/locations")]
    public class LocationController : ApiController
    {
        private LocationManager _locationManager;

        public LocationController()
        {
            _locationManager = new LocationManager(new EfLocationRepo());
        }

        [HttpGet,Route("")]
        public IList<Location> GetAll()
        {
            return _locationManager.GetAll();
        }

        [HttpPost,Route("")]
        public Location Create(Location location)
        {
            return _locationManager.Create(location);
        }

        [HttpGet,Route("{id}")]
        public Location GetById(long id)
        {
            return _locationManager.GetById(id);
        }

        [HttpDelete, Route("{id}")]
        public bool Delete(long id)
        {
            var location = _locationManager.GetById(id);

            return _locationManager.Delete(location);
        }

        [HttpPut,Route("{id}")]
        public Location Update(long id, Location location)
        {
            location.LocationId = id;

            return _locationManager.Update(location);
        }
    }
}
