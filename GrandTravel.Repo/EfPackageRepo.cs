using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using System.Data.Entity;

namespace GrandTravel.Repo
{
    public interface IPackageRepo : IRepository<Package>
    {
        IList<Package> getByName(string name);
    }

    public class EfPackageRepo : BaseEFRepository<Package>, IPackageRepo
    {
        private GrandTravelContext _context;
        private DbSet<Package> _dbSet;


        public EfPackageRepo()
        {
            _context = new GrandTravelContext();
            _dbSet = _context.Set<Package>();
        }

        public IList<Package> getByName(string name)
        {
            IEnumerable<Package> queryPackages = _dbSet.Where(p => p.Name.Contains(name));

            if(queryPackages != null)
            {
                IList<Package> Packages = queryPackages.ToArray<Package>();
                return Packages;
            } 
            else 
            {
                return null;
            }
        }
        public IList<Package> GetByNameAndLocation(string name, long locationId)
        {
            IEnumerable<Package> queryPackages = _dbSet.Where(p => p.Name.Contains(name) && p.LocationId == locationId);

            if (queryPackages != null)
            {
                IList<Package> Packages = queryPackages.ToArray<Package>();
                return Packages;
            }
            else
            {
                return null;
            }
        }
    }
}
