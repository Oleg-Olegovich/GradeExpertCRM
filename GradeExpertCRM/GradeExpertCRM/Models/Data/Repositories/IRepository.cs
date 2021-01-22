using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeExpertCRM.Models.Data.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
        T Add(T item);
        Task<T> AddAsync(T item);
        Task<T> FindByIdAsync(int id);
        void Remove(T item);
        T Update(T item);
        Task RemoveAsync(T item);
        Task<T> UpdateAsync(T item);
    }
}
