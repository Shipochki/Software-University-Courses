using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using static CarRacing.Utilities.Messages.ExceptionMessages;
using System.Text;
using System.Linq;

namespace CarRacing.Repositories.Models
{
    public class CarRepository : IRepository<ICar>
    {
        public CarRepository()
        {
            models = new List<ICar>();
        }

        private List<ICar> models;

        public IReadOnlyCollection<ICar> Models => models;


        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(InvalidAddCarRepository);
            }

            models.Add(model);
        }

        public ICar FindBy(string property)
        {
            return models.FirstOrDefault(m => m.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }
    }
}
