using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTravel.Entity
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public long PackageId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string AuthorizedBy { get; set; }

        //a reference of many relationship
        public virtual IList<OrderLineItem> OrderLineItemsList { get; set; }

        public Order()
        {
            OrderLineItemsList = new List<OrderLineItem>();
        }
    }
}
