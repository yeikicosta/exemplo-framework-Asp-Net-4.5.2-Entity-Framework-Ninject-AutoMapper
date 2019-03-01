using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunicationAPI
{
    public interface ICommAPI<T>
    {
        Task<int> AddAsync(T obj);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T obj);
    }
}