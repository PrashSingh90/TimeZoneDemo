using Guest_BO.DataModel;
using Guest_DAL.Data;
using Guest_DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Guest_DAL.Repository
{
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        private readonly ApplicationDbContext _context;

        public GuestRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override int Update(Guest guestObj)
        {
            try
            {
                // need to be implemented 
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public override int Remove(Expression<Func<Guest, bool>> filter)
        {
            try
            {
                // need to be implemented 
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
