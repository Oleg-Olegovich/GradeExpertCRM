using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Splat;

namespace GradeExpertCRM.Models.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T: class, new()
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext = null)
        {
            _dbContext = dbContext ?? Locator.Current.GetService<AppDbContext>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T item)
        {
            await _dbContext.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task RemoveAsync(T item)
        {
            _dbContext.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            _dbContext.Update(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }
    }
}
