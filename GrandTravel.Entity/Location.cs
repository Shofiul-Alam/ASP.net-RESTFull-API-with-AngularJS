using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTravel.Entity
{
    public class Location
    {
        [Key]
        public long LocationId { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }

        public virtual IList<Package> Packages { get; set; }
        public Location()
        {
            Packages = new List<Package>();
        }
    }
}
