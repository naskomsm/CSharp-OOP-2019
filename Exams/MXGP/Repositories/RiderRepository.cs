namespace MXGP.Repositories
{
    using MXGP.Models.Riders;
    using System.Collections.Generic;

    public class RiderRepository : Repository<Rider>
    {
        private readonly List<Rider> riders;

        public RiderRepository()
        {
            this.riders = new List<Rider>();
        }

        public override void Add(Rider rider)
        {
            this.riders.Add(rider);
        }

        public override IReadOnlyCollection<Rider> GetAll()
            => this.riders.AsReadOnly();

        public override Rider GetByName(string name)
        {
            return this.riders.Find(x => x.Name == name);
        }

        public override bool Remove(Rider rider)
        {
            return this.riders.Remove(rider);
        }
    }
}
