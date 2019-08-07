namespace MXGP.Repositories
{
    using MXGP.Models.Motorcycles;
    using System.Collections.Generic;

    public class MotorcycleRepository<T> : Repository<Motorcycle>
    {
        private readonly List<Motorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<Motorcycle>();
        }

        public override void Add(Motorcycle model)
        {
            this.motorcycles.Add(model);
        }

        public override IReadOnlyCollection<Motorcycle> GetAll()
            => this.motorcycles.AsReadOnly();

        public override Motorcycle GetByName(string model)
        {
            return this.motorcycles.Find(x => x.Model == model);
        }

        public override bool Remove(Motorcycle model)
        {
            return this.motorcycles.Remove(model);
        }
    }
}
