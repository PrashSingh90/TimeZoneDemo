using Guest_BO.DataModel;
using Guest_DAL.Data;
using Guest_DAL.IRepository;


namespace Guest_DAL.Repository
{
    public class PhoneRepository : Repository<PhoneNumber>, IPhoneRepository
    {
        private readonly ApplicationDbContext _context;

        public PhoneRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
