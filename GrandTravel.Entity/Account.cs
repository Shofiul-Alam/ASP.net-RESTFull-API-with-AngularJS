using GrandTravel.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTravel.Entity
{
      public class Account
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public RoleEnum Role { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime  lastLogin { get; set; }

    }
}
