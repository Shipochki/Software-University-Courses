using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
	public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
	{
		private List<IFormulaOneCar> models = new List<IFormulaOneCar>();

		public IReadOnlyCollection<IFormulaOneCar> Models => models;


		public void Add(IFormulaOneCar model)
		{
			this.models.Add(model);
		}

		public IFormulaOneCar FindByName(string name)
		{
			return this.models.FirstOrDefault(m => m.Model == name);
		}

		public bool Remove(IFormulaOneCar model)
		{
			if(this.models.Contains(model))
			{
				this.models.Remove(model);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
