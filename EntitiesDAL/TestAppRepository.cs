using EntitiesDAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EntitiesDAL
{
    public abstract class TestAppRepository<T> : ITestAppRepository<T> where T : class
    {
        private readonly DbContext _db;

        public TestAppRepository(DbContext context)
        {
            _db = context;
        }

        public virtual async Task<List<T>> GetListAsNoTracking()
        {
            return await _db.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> Find(int id)
        {
            var item = await _db.Set<T>().FindAsync(id);
            return item;
        }

        public virtual async Task Create(T item)
        {
            await _db.Set<T>().AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public virtual async Task Update(T item)
        {
            _db.Set<T>().Update(item);
            await _db.SaveChangesAsync();
        }

        public virtual async Task Delete(T item)
        {
            _db.Set<T>().Remove(item);
            await _db.SaveChangesAsync();
        }

        public virtual async Task AddRange(IEnumerable<T> items)
        {
            await _db.Set<T>().AddRangeAsync(items);
            await _db.SaveChangesAsync();
        }

        public virtual async Task DeleteRange(IEnumerable<T> items)
        {
            _db.Set<T>().RemoveRange(items);
            await _db.SaveChangesAsync();
        }

        public virtual async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
