using Guest_BAL.IServices;
using Guest_DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Guest_BAL.Services
{
    public class Service<T, R> : IService<T, R> where T : class
                                             where R : class
    {
        public readonly IRepository<T> _respository;
        public Service(IRepository<T> respository)
        {
            _respository = respository;
        }
        public List<T> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            try
            {
                var tDatas = _respository.GetAll(filter);
                return tDatas != null ? tDatas : new List<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public T? Get(Expression<Func<T, bool>> filter)
        {
            try
            {
                var tData = _respository.Get(filter);
                return tData != null ? tData : default;
            }
            catch
            {
                return default;
            }
        }
        public int Add(T obj)
        {
            try
            {
                return _respository.Add(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
    }
}
