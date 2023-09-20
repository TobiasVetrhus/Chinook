namespace Chinook.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> GetByName(string FirstName);
        IEnumerable<T> GetPage(int limit, int offset);
        bool Add(T entity);
        bool Update(T entity);
    }
}
