using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTravel.Entity.Enums
{
    public class StatusEnum
    {
        public string Active { get; set; }
        public string Applied_For_TravelProvider { get; set; }
        public string Applied_For_Admin { get; set; }
        public string inActive { get; set; }

        public StatusEnum()
        {
            Active = "Active";
            Applied_For_TravelProvider = "Applied For Travel Provider";
            Applied_For_Admin = "Applied For Admin";
            inActive = "Inactive";
        }
    }
}
