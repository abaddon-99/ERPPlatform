

namespace ERP.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T Create(T value);
        T Update(T value);
        bool Remove(T value);
        T? GetById(int id);
        bool IsExist(int id);
    }
}