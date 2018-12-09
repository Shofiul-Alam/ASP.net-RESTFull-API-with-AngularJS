using GrandTravel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrandTravel.Angular.Library
{
    public class ShoppingCart
    {
        public static List<OrderLineItem> CartItems
        {
            get
            {
                if (HttpContext.Current.Session["CartItems"] == null)
                {
                    HttpContext.Current.Session["CartItems"] = new List<OrderLineItem>();
                }
                return (List<OrderLineItem>)HttpContext.Current.Session["CartItems"];
            }
            set
            {
                HttpContext.Current.Session["CartItems"] = value;
            }
        }
    }
}