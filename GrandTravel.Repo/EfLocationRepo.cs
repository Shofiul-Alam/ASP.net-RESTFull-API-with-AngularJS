using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;

namespace GrandTravel.Repo
{
    public interface ILocationRepo : IRepository<Location>
    {
    }

    public class EfLocationRepo : BaseEFRepository<Location>, ILocationRepo
    {
    }
}
