using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrandTravel.Angular.Models
{
    public class PayPalProduct
    {

        public long item_number { get; set; }

        public string item_name { get; set; }

        public decimal amount { get; set; }

        public int quantity { get; set; }
    }
}