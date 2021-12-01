using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Forum.Infra.Repository.Contracts
{
    public interface IRepository<T> where T: class
    {
        Task<T> Get(string Id);
        Task<IEnumerable<T>> GetTop10();
        Task<IEnumerable<T>> GetTop25();
        Task<IEnumerable<T>> GetTop50();
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        
    }
}
