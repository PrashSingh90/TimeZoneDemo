using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Guest_BAL.IServices
{
    public interface IService<T, R> where T : class
                                  where R : class
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        T? Get(Expression<Func<T, bool>> filter);
        int Add(T guestObj);
      
    }
}
