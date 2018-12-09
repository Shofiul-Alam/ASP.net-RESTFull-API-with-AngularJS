using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;
using System.Data.Entity;


namespace GrandTravel.Repo
{
    public interface ICustomerRepo: IRepository<Customer>
    {
        Customer getByEmail(string email);
        long getLastId();
    }

    public class EfCustomerRepo : BaseEFRepository<Customer>, ICustomerRepo
    {
        private GrandTravelContext _context;
        private DbSet<Customer> _dbSet;


        public EfCustomerRepo()
        {
            _context = new GrandTravelContext();
            _dbSet = _context.Set<Customer>();
        }


        public Customer getByEmail(string email)
        {
           IEnumerable<Customer> userEmail = _dbSet.Where(p => p.Email == email);

            if(userEmail.Count<Customer>() != 0)
            {
                var user = userEmail.First();
                return user;
            } 
            else
            {   
                return null;
            }
            
        }
        public Customer getBySecureId(string secureId)
        {
            IEnumerable<Customer> user = _dbSet.Where(p => p.HashId == secureId);

            if (user.Count<Customer>() != 0)
            {
                var currentUser = user.First();
                return currentUser;
            }
            else
            {
                return null;
            }

        }

        public long getLastId()
        {
            var last = _dbSet.FirstOrDefault(c => c.CustomerId == _dbSet.Max(x => x.CustomerId));
            if(last != null) { 
            var lastId = last.CustomerId;
            return lastId;
            } else
            {
                return 0;
            }
        }

        public bool deleteBySecureId(Customer customer)
        {

            _dbSet.Remove(customer);
            int result = _context.SaveChanges();

            return result > 0;
        }
    }
}
