using System.Collections.Generic;

namespace DataAccess
{
    public interface IRepository<T>
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T Find(int key);
        void Remove(int key);
        void Update(T item);
        void Initialize();

    }
}
