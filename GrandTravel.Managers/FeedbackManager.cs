using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using GrandTravel.Repo;

namespace GrandTravel.Managers
{
    public class FeedbackManager
    {
        private IRepository<Feedback> _feedbackRepo;

        public FeedbackManager(IRepository<Feedback> feedbackRepo)
        {
            _feedbackRepo = feedbackRepo;
        }
        public Feedback Create(Feedback feedback)
        {
            return _feedbackRepo.Create(feedback);
        }

        public bool Delete(Feedback feedback)
        {
            return _feedbackRepo.Delete(feedback);
        }

        public IList<Feedback> GetAll()
        {
            return _feedbackRepo.GetAll();
        }

        public Feedback GetById(long id)
        {
            return _feedbackRepo.GetById(id);
        }

        public Feedback Update(Feedback feedback)
        {
            return _feedbackRepo.Update(feedback);
        }
    }
}
