using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories
{
	public class PilotRepository : IRepository<IPilot>
	{
		private List<IPilot> models = new List<IPilot>();

		public IReadOnlyCollection<IPilot> Models => models;


		public void Add(IPilot model)
		{
			this.models.Add(model);
		}

		public IPilot FindByName(string name)
		{
			return this.models.FirstOrDefault(m => m.FullName == name);
		}

		public bool Remove(IPilot model)
		{
			if (this.models.Contains(model))
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
