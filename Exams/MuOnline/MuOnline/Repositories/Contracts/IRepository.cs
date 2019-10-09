namespace MuOnline.Repositories.Contracts
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Repository { get; }

        void Add(T item);

        string Remove(T item);

        T Get(string item);
    }
}
