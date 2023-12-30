namespace ERP.Application.Interfaces.Services
{
    public interface IBaseService<T>
    {
        Task<T> CreateAsync(T value);
        T Update(T value);
        void Remove(T value);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<bool> IsExistAsync(int id);
    }
}