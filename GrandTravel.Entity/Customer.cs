using GrandTravel.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GrandTravel.Entity
{
    public class Customer
    {
        [Key]
        public long CustomerId { get; set; }
        public string HashId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public RoleEnum Authorization { get; set; }
       // public HttpPostedFileBase Image { get; set; }
        public virtual IList<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}
