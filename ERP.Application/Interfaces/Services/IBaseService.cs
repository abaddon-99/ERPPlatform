namespace ERP.Application.Interfaces.Services
{
    public interface IBaseService<T>
    {
        T Create(T value);
        T Update(T value);
        bool Remove(T value);
        IEnumerable<T> GetAll();
        T? GetById(int id);
        bool IsExist(int id);
    }
}