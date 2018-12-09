using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using GrandTravel.Entity;
using GrandTravel.Managers;
using GrandTravel.Repo;
using System.Security.Claims;
using GrandTravel.Angular.Models;
using GrandTravel.Angular.Library;
using System.IO;

namespace GrandTravel.Angular.Controllers
{
    [Authorize(Roles = "TravelProvider, Admin")]
    [RoutePrefix("api/packages")]
    public class PackageController : ApiController
    {
        private PackageManager _packageManager;
        private LocationManager _locationManager;
        private TravelProviderManager _travelProviderManager;
        private EfPackageRepo _package;
        private PhotoGalleryManager _galleryManager;
        private OrderManager _orderManager;
        private EfOrderRepo _efOrderManager;
        private OrderLineItemManager _orderLineItemManager;
        private EfOrderLineItemRepo _efOrderLineItemRepo;
        private FeedbackManager _feedbackManager;
        private EfFeedbackRepo _feedback;


        public PackageController()
        {
            _packageManager = new PackageManager(new EfPackageRepo());
            _travelProviderManager = new TravelProviderManager(new EfTravelProviderRepo());
            _locationManager = new LocationManager(new EfLocationRepo());
            _package = new EfPackageRepo();
            _galleryManager = new PhotoGalleryManager(new EfPackagesPhotoGallery());
            _orderManager = new OrderManager(new EfOrderRepo());
            _efOrderManager = new EfOrderRepo();
            _orderLineItemManager = new OrderLineItemManager(new EfOrderLineItemRepo());
            _efOrderLineItemRepo = new EfOrderLineItemRepo();
            _feedbackManager = new FeedbackManager(new EfFeedbackRepo());
            _feedback = new EfFeedbackRepo();
            
        }

        [AllowAnonymous]
        [HttpGet,Route("")]
        public IList<Package> GetAll()
        {
            return _packageManager.GetAll();
        }


        [AllowAnonymous]
        [HttpGet, Route("{id}")]
        public Package GetById(long id)
        {
            var package = _packageManager.GetById(id);

            int maxRatting = 0;

            for(var i = 0; i< package.FeedBackList.Count(); i++)
            {
                if(package.FeedBackList[i].Ratting > maxRatting)
                {
                    maxRatting = package.FeedBackList[i].Ratting;
                }
                
            }
           
            for (var i = 0; i < package.FeedBackList.Count(); i++)
            {
                package.FeedBackList[i].Ratting = maxRatting;
            }


            return package;
        }

        [AllowAnonymous]
        [HttpGet, Route("carts")]

        public IList<OrderLineItem> getCarts()
        {


            return ShoppingCart.CartItems;
        }


        [AllowAnonymous]
        [HttpPost, Route("addToCart")]
        public IList<OrderLineItem> addToCart(OrderLineItem orderLineItem)
        {
            var cartItem = _packageManager.GetById(orderLineItem.PackageId);
            OrderLineItem lineItem = new OrderLineItem();
            lineItem.PackageId = cartItem.PackageId;
            lineItem.PackageName = cartItem.Name;
            lineItem.Quantity = orderLineItem.Quantity;
            lineItem.Price = cartItem.Price * lineItem.Quantity;
      //    lineItem.OrderId = 1;

            ShoppingCart.CartItems.Add(lineItem);


            return ShoppingCart.CartItems;

        }

        [AllowAnonymous]
        [HttpGet, Route("addToCart/{id}")]
        public IList<OrderLineItem> addToCartById(long id)
        {
            var cartItem = _packageManager.GetById(id);
            OrderLineItem lineItem = new OrderLineItem();
            lineItem.PackageId = cartItem.PackageId;
            lineItem.PackageName = cartItem.Name;
            lineItem.Quantity = 1;
            lineItem.Price = cartItem.Price * lineItem.Quantity;
            //    lineItem.OrderId = 1;

            ShoppingCart.CartItems.Add(lineItem);


            return ShoppingCart.CartItems;

        }

        [AllowAnonymous]
        [HttpGet, Route("RemoveCartItem/{packageId}")]
        public IList<OrderLineItem> removeCartItem(long packageId)
        {
            IList<OrderLineItem> packages = ShoppingCart.CartItems ;

            var cartItem = packages.FirstOrDefault(p => p.PackageId == packageId);
            if(cartItem != null)
            {
                ShoppingCart.CartItems.Remove(cartItem);

                return ShoppingCart.CartItems;
            }
            {
                return ShoppingCart.CartItems;
            }
           

        }

        [HttpPost,Route("")]
        public Package Create()
        {
            Package package = new Package();

            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = HttpContext.Current.Server.MapPath("~/uploads/packages/");

            var uploadedFiles = HttpContext.Current.Request.Files;
            HttpPostedFile uploadedFile;

            // CHECK THE FILE COUNT.
            for (int i = 0; i <= uploadedFiles.Count - 1; i++)
            {
                uploadedFile = uploadedFiles[i];
                package.FeaturePhoto = "http://webnetscommerce.azurewebsites.net/uploads/packages/" + uploadedFile.FileName;

                if (uploadedFile.ContentLength > 0)
                {

                    string savePath = Path.Combine(sPath, Path.GetFileName(uploadedFile.FileName));
                    // TODO: CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    // SAVE THE FILES IN THE FOLDER.
                    uploadedFile.SaveAs(savePath);

                }
            }



            var newPackage = HttpContext.Current.Request.Form;

            Claim sessionEmail = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Sid);
            long customerId = Convert.ToInt32(sessionEmail.Value);
            var travelProvider = _travelProviderManager.Query(u => u.CustomerId == customerId).First();
            var travelProviderId = travelProvider.TravelProviderId;
            package.TravelProviderId = travelProviderId;
            package.Date = DateTime.Now;
            package.Name = newPackage["Package[Name]"];
            package.Description = newPackage["Package[Description]"];
            package.LocationId = Convert.ToInt32(newPackage["Package[LocationId]"]);
            package.Price = Convert.ToDecimal(newPackage["Package[Price]"]);


            return _packageManager.Create(package);
        }

        [HttpPost, Route("PhotoGallery")]
        public PackagesPhotoGallery AddToGallery()
        {
            PackagesPhotoGallery package = new PackagesPhotoGallery();

            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = HttpContext.Current.Server.MapPath("~/uploads/packages/gallery/");

            var uploadedFiles = HttpContext.Current.Request.Files;
            HttpPostedFile uploadedFile;
            string galleryUrls = "";

            var formReq = HttpContext.Current.Request.Form;
            var x = formReq[0];

            // CHECK THE FILE COUNT.
            for (int i = 0; i <= uploadedFiles.Count - 1; i++)
            {
                uploadedFile = uploadedFiles[i];

                galleryUrls = "/uploads/packages/gallery/" + uploadedFile.FileName;

                if (uploadedFile.ContentLength > 0)
                {

                    string savePath = Path.Combine(sPath, Path.GetFileName(uploadedFile.FileName));
                    // TODO: CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    // SAVE THE FILES IN THE FOLDER.
                    uploadedFile.SaveAs(savePath);

                }
            }





            var newPackage = HttpContext.Current.Request.Form;

            Claim sessionEmail = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Sid);
            long customerId = Convert.ToInt32(sessionEmail.Value);
            var travelProvider = _travelProviderManager.Query(u => u.CustomerId == customerId).First();
            var travelProviderId = travelProvider.TravelProviderId;
            package.urls = galleryUrls;
            package.PackageId = 1;
            



            return _galleryManager.Create(package);
        }

        [AllowAnonymous]

        [HttpPost, Route("search")]
        public IList<Package> searchResult(SearchQuery searchQuery)
        {
            if(searchQuery.LocationId != 0)
            {
                var locationPackages = _locationManager.GetById(searchQuery.LocationId);

                var Packages = locationPackages.Packages;

                return Packages;
            }
            else if(searchQuery.PackageName != null)
            {
                var Packages = _package.getByName(searchQuery.PackageName);
                return Packages;
            }
            else
            {
                return null;
            }
            
        }


        [HttpDelete, Route("{id}")]
        public bool Delete(long id)
        {
            var package = _packageManager.GetById(id);

            return _packageManager.Delete(package);
        }

        [HttpPut,Route("{id}")]
        public Package Update(long id, Package package)
        {
            package.PackageId = id;

            return _packageManager.Update(package);
        }

        [HttpPost, Route("AddOrder")]

        public PackageView Add(List<OrderLineItem> orderLineItems)
        {
            Order newOrder = new Order();

            newOrder.OrderDate = DateTime.Now;
            Claim sessionCustomerId = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Sid);
            Claim customerName = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name);
            long customerId = Convert.ToInt32(sessionCustomerId.Value);
            newOrder.CustomerId = customerId;

            _efOrderManager.Create(newOrder);

            var LastOrderId = _efOrderManager.getLastOrderId();

            for(var i = 0; i < orderLineItems.Count; i++ )
            {
                OrderLineItem empty = new OrderLineItem();

                var lineItem = orderLineItems[i];

                lineItem.OrderId = LastOrderId;
                lineItem.OdLnNo = empty.OdLnNo;

                _efOrderLineItemRepo.Create(lineItem);
            }

            long updatedOrderId = _efOrderManager.getLastOrderId();

            var createdOrder = _orderManager.GetById(updatedOrderId);

            PackageView OrderDetails = new PackageView();
            

            OrderDetails.OrderId = updatedOrderId;
            OrderDetails.LineItems = createdOrder.OrderLineItemsList;
            OrderDetails.CustomerName = customerName.Value;
            OrderDetails.orderDate = newOrder.OrderDate;



            for (var i = 0; i < OrderDetails.LineItems.Count(); i++)
            {
                LineItem newLineItem = new LineItem();

                var pack = _packageManager.GetById(OrderDetails.LineItems[i].PackageId);

                newLineItem.item_name = pack.Name;
                newLineItem.amount = pack.Price;
                newLineItem.ItemPhoto = pack.FeaturePhoto;
                newLineItem.quantity = OrderDetails.LineItems[i].Quantity;

                OrderDetails.GrandTotal += (newLineItem.amount * newLineItem.quantity);

                OrderDetails.DetailsLineItems.Add(newLineItem);

            }



            HttpContext.Current.Session["PayPalPayment"] = new PackageView();

            HttpContext.Current.Session["PayPalPayment"] = OrderDetails;

            return OrderDetails;
        }
        
        [HttpPost, Route("feedback")]

        public IList<Feedback> addFeedback(Feedback feedback)
        {
            Claim sessionEmail = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Sid);
            long customerId = Convert.ToInt32(sessionEmail.Value);

            Feedback newFeedback = new Feedback();
            newFeedback.CustomerId = customerId;
            newFeedback.FeedBackDate = DateTime.Now;
            newFeedback.PackageId = feedback.PackageId;
            newFeedback.FeedbackDetails = feedback.FeedbackDetails;
            newFeedback.Ratting = feedback.Ratting;

            _feedbackManager.Create(newFeedback);

            var feedbacks =  _feedback.getByPackageId(feedback.PackageId);
          

            return feedbacks; 
        }
        [AllowAnonymous]
        [HttpGet, Route("feedback/{id}")]

        public IList<Feedback> getAllFeedback(long id)
        {
            
            var AllFeedback = _feedback.getByPackageId(id);

            return AllFeedback;
        }

    }
}
