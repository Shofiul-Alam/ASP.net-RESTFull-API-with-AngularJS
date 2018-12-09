using GrandTravel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrandTravel.Angular.Models
{
    public class PackageView
    {
        public string CustomerName { get; set; }
        public long PackageId { get; set; }
        public long OdLnNo { get; set; }
        public long OrderId { get; set; }
        public string PackageName { get; set; }
        public string FeaturePhoto { get; set;}
        public decimal Price { get; set; }
        public decimal GrandTotal { get; set; }
        public int Quantity { get; set; }
        public DateTime orderDate { get; set; }
        public IList<LineItem> DetailsLineItems { get; set; }
        public virtual IList<OrderLineItem> LineItems { get; set; }

        public PackageView()
        {
            DetailsLineItems = new List<LineItem>();

        }


    }
}