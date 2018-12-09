using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrandTravel.Entity
{
   public class Package
    {
        [Key]
        public long PackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long LocationId { get; set; }
        public string Accommodation { get; set; }
        public DateTime Date { get; set; }
        public long TravelProviderId { get; set; }
        public decimal Price { get; set; }
        public string FeaturePhoto { get; set; }
        public virtual IList<string> PhotoGallery { get; set; }
        public virtual IList<PackagesPhotoGallery> Gallery { get; set; }

        //a reference of many relationship
        public virtual IList<Feedback> FeedBackList { get; set; }

        public Package()
        {
            FeedBackList = new List<Feedback>();
            Gallery = new List<PackagesPhotoGallery>();
        } 
            
    }
}
