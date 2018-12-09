using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using GrandTravel.Repo;

namespace GrandTravel.Managers
{
    public class PhotoGalleryManager
    {
        private IRepository<PackagesPhotoGallery> _galleryRepo;

        public PhotoGalleryManager(IRepository<PackagesPhotoGallery> galleryRepo)
        {
            _galleryRepo = galleryRepo;
        }
        public PackagesPhotoGallery Create(PackagesPhotoGallery photoGallery)
        {
            return _galleryRepo.Create(photoGallery);
        }

        public bool Delete(PackagesPhotoGallery photoGallery)
        {
            return _galleryRepo.Delete(photoGallery);
        }

        public IList<PackagesPhotoGallery> GetAll()
        {
            return _galleryRepo.GetAll();
        }

        public PackagesPhotoGallery GetById(long id)
        {
            return _galleryRepo.GetById(id);
        }

        public PackagesPhotoGallery Update(PackagesPhotoGallery photoGallery)
        {
            return _galleryRepo.Update(photoGallery);
        }
    }
}
