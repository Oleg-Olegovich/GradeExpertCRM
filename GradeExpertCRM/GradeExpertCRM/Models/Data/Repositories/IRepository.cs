using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeExpertCRM.Models.Data.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T item);
        Task RemoveAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T> FindByIdAsync(int id);
    }
}
