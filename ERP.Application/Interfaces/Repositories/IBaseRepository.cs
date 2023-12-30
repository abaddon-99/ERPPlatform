

namespace ERP.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> : IDisposable
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T value);
        T Update(T value);
        void Remove(T value);
        Task<T?> GetByIdAsync(int id);
        Task<bool> IsExistAsync(int id);
    }
}