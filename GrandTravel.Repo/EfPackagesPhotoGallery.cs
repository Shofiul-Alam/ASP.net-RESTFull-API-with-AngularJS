using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;

namespace GrandTravel.Repo
{
    public interface IPackagesPhotoGallery : IRepository<PackagesPhotoGallery>
    {
    }

    public class EfPackagesPhotoGallery : BaseEFRepository<PackagesPhotoGallery>, IPackagesPhotoGallery
    {
    }
}
