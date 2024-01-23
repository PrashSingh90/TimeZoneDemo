using Guest_BO.DataModel;
using Guest_DAL.Data;
using Guest_DAL.IRepository;

namespace Guest_DAL.Repository
{
    public class TitleRepository : Repository<Title>, ITitleRepository
    {
        private readonly ApplicationDbContext _context;

        public TitleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
       
    }
}
