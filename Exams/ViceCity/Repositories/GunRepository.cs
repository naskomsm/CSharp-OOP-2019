namespace ViceCity.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Repositories.Contracts;

    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models
            => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            var searchedModel = this.models.FirstOrDefault(x=>x.Name == model.Name);

            if(searchedModel == null)
            {
                this.models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IGun model)
        {
            var searchedModel = this.models.FirstOrDefault(x => x.Name == model.Name);

            return this.models.Remove(searchedModel);
        }
    }
}
