namespace MXGP.Repositories
{
    using MXGP.Models.Motorcycles.Contracts;
    using System.Collections.Generic;

    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public override void Add(IMotorcycle motorcycle)
        {
            this.motorcycles.Add(motorcycle);
        }

        public override IReadOnlyCollection<IMotorcycle> GetAll()
            => this.motorcycles.AsReadOnly();

        public override IMotorcycle GetByName(string model)
        {
            return this.motorcycles.Find(x => x.Model == model);
        }

        public override bool Remove(IMotorcycle motorcycle)
        {
            return this.motorcycles.Remove(motorcycle);
        }
    }
}
