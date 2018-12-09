using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using GrandTravel.Entity.Enums;

namespace GrandTravel.Entity
{
    public class TravelProvider
    {
        [Key]
        public long TravelProviderId { get; set; }
        public long CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ManagerName { get; set; }
        public string ABN { get; set; }
        public string CompanyAddress { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }


        public virtual IList<Package> Packages { get; set; }

        public TravelProvider()
        {
            Packages = new List<Package>();
        }

    }
}
