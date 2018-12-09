using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTravel.Entity
{
   public class Feedback
    {
        [Key]
        public long FeedBackId { get; set; }
        public long PackageId { get; set; }
        public long CustomerId { get; set; }
        public DateTime FeedBackDate { get; set; }
        public string FeedbackDetails { get; set; }
        public int Ratting { get; set; }
    }
}
