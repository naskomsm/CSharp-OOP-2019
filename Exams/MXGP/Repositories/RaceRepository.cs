namespace MXGP.Repositories
{
    using MXGP.Models.Races;
    using System.Collections.Generic;

    public class RaceRepository : Repository<Race>
    {
        private readonly List<Race> races;

        public RaceRepository()
        {
            this.races = new List<Race>();
        }

        public override void Add(Race race)
        {
            this.races.Add(race);
        }

        public override IReadOnlyCollection<Race> GetAll()
            => this.races.AsReadOnly();

        public override Race GetByName(string name)
        {
            return this.races.Find(x => x.Name == name);
        }

        public override bool Remove(Race race)
        {
            return this.races.Remove(race);
        }
    }
}
