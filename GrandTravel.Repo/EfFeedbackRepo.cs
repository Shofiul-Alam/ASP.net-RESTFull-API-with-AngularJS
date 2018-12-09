using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using System.Data.Entity;

namespace GrandTravel.Repo
{
    public interface IFeedbackRepo : IRepository<Feedback>
    {
    }

    public class EfFeedbackRepo : BaseEFRepository<Feedback>, IFeedbackRepo
    {
        private GrandTravelContext _context;
        private DbSet<Feedback> _dbSet;


        public EfFeedbackRepo()
        {
            _context = new GrandTravelContext();
            _dbSet = _context.Set<Feedback>();
        }


        public IList<Feedback> getByPackageId(long id)
        {
            IEnumerable<Feedback> feedbacksQuery = _dbSet.Where(p => p.PackageId == id);

            if (feedbacksQuery.Count<Feedback>() != 0)
            {
                var feedbacks = feedbacksQuery.ToList<Feedback>();
                return feedbacks;
            }
            else
            {
                return null;
            }

        }
    }
}
