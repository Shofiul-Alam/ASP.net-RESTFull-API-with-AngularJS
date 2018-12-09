using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrandTravel.Entity
{
    public class OrderLineItem
    {
        [Key]
        public long OdLnNo { get; set; }
        public long OrderId { get; set; }
        public long PackageId { get; set; }
        public string PackageName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
