using Guest_BAL.IServices;
using Guest_BO.DataModel;
using Guest_DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_BAL.Services
{
    public class TitleService : Service<Title, ITitleRepository>, ITitleService
    {
        public TitleService(ITitleRepository titleRepository) : base(titleRepository)
        {

        }

    }
}
