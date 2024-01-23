using Guest_BO.DataModel;
using Guest_DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_BAL.IServices
{
    public interface ITitleService : IService<Title, ITitleRepository>
    {

    }
}
