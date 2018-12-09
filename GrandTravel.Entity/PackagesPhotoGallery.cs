using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTravel.Entity
{
    public class PackagesPhotoGallery
    {
        [Key]
        public long GalleryId { get; set; }
        public long PackageId { get; set; }
        public string urls { get; set; }
    }
}
