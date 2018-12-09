using GrandTravel.Angular.Library;
using GrandTravel.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GrandTravel.Angular.Controllers
{
    public class PaymentCompleteController : Controller
    {
        // GET: PaymentComplete
       public ActionResult Index()
        {
            PackageView PaypalOrder = new PackageView();
            string body = "";

            PaypalOrder = HttpContext.Session["PayPalPayment"] as PackageView;
            if(PaypalOrder != null) { 
                    body = "<h4>Order No:" + PaypalOrder.OrderId + "</h4>" +
                          "<h4>Customer Name:" + PaypalOrder.CustomerName + "</h4>" +
                          "<h4>Order Date:" + PaypalOrder.orderDate + "</h4>" +
                          "<table width='500' ><th>PackageName</th><th>Quanity</th><th>Value</th><th>Price</th>";

            for (var i = 0; i < PaypalOrder.DetailsLineItems.Count; i++)
            {
                body += "<tr><td>" + PaypalOrder.DetailsLineItems[i].item_name + "</td><td>" 
                                    + PaypalOrder.DetailsLineItems[i].quantity +
                        "</td><td>" + PaypalOrder.DetailsLineItems[i].amount + "</td><td>" 
                                    + PaypalOrder.DetailsLineItems[i].amount * PaypalOrder.DetailsLineItems[i].quantity +
                        "</td></tr>";
            }

            body += "</table>";
                body += "<hr/><h3>Grand Total=" + PaypalOrder.GrandTotal + "</h3>";
            }
            else
            {
                body = "";
            }


            GMailer.GmailUsername = "shofi.tafe@gmail.com";
            GMailer.GmailPassword = "AlamPabna_7991";

            GMailer mailer = new GMailer();
            mailer.ToEmail = "mr.shofiul.alam@gmail.com";
            mailer.Subject = "Verify your email id";
            mailer.Body = body;
            mailer.IsHtml = true;
            mailer.Send();
           
            return View(PaypalOrder);
        }

    }
}