using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Splat;

namespace GradeExpertCRM.Models.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly AppDbContext dbContext_;

        public Repository(AppDbContext dbContext = null)
        {
            dbContext_ = dbContext ?? Locator.Current.GetService<AppDbContext>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext_.Set<T>().ToList();
        }

        public T Add(T item)
        {
            dbContext_.Add(item);
            dbContext_.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item)
        {
            await dbContext_.AddAsync(item);
            await dbContext_.SaveChangesAsync();
            return item;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await dbContext_.FindAsync<T>(id);
        }

        public void Remove(T item)
        {
            dbContext_.Remove(item);
            dbContext_.SaveChanges();
        }

        public T Update(T item)
        {
            dbContext_.Update(item);
            dbContext_.SaveChanges();
            return item;
        }

        public async Task RemoveAsync(T item)
        {
            dbContext_.Remove(item);
            await dbContext_.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            dbContext_.Update(item);
            await dbContext_.SaveChangesAsync();
            return item;
        }
    }
}
