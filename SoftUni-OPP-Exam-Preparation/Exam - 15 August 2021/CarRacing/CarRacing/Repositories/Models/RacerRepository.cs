using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CarRacing.Utilities.Messages.ExceptionMessages;

namespace CarRacing.Repositories.Models
{
    public class RacerRepository : IRepository<IRacer>
    {
        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        private List<IRacer> models;

        public IReadOnlyCollection<IRacer> Models => models;


        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(InvalidAddRacerRepository);
            }

            models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return models.FirstOrDefault(m => m.Username == property);
        }

        public bool Remove(IRacer model)
        {
            return models.Remove(model);
        }
    }
}
