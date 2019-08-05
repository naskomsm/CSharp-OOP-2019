namespace AnimalCentre.Models.Proceedurs
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AnimalCentre.Models.Contracts;

    public abstract class Procedure : IProcedure
    {
        protected ICollection<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");
            foreach (var procedure in procedureHistory)
            {
                sb.AppendLine(procedure.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (procedureTime > animal.ProcedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;
        }
    }
}
