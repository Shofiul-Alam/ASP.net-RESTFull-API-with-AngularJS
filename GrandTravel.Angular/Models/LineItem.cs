using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrandTravel.Angular.Models
{
    public class LineItem
    {

        public long item_number { get; set; }

        public string item_name { get; set; }

        public decimal amount { get; set; }

        public int quantity { get; set; }

        public string ItemPhoto { get; set; }
    }
}