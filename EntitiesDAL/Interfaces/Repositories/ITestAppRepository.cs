using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesDAL.Interfaces.Repositories
{
    public interface ITestAppRepository<T> : IDisposable where T : class
    {
        Task<List<T>> GetListAsNoTracking();
        Task<T?> Find(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(T item);
        Task AddRange(IEnumerable<T> items);
        Task DeleteRange(IEnumerable<T> items);
        Task Save();
    }
}
