namespace MXGP.Repositories
{
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;

    public abstract class Repository<T> : IRepository<T>
    {
        public abstract void Add(T model);

        public abstract IReadOnlyCollection<T> GetAll();

        public abstract T GetByName(string name);

        public abstract bool Remove(T model);
    }
}
