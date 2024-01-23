using Guest_BO.DataModel;
using Guest_BO.DTOModel.PhoneNumber;
using Guest_DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Guest_BAL.IServices
{
    public interface IGuestPhoneNumberService : IService<GuestPhoneNumber, IGuestPhoneNumberRepository>
    {
        public GuestPhoneNumberDTO GetPhoneDetails(Expression<Func<GuestPhoneNumber, bool>>? filter = null);
    }
}
