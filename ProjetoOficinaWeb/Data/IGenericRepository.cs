using System.Linq;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> ExistAsync(int id);
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
    }
}