using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Repositories
{
	public class VesselRepository : IRepository<IVessel>
	{
		public VesselRepository()
		{
			this.models = new List<IVessel>();
		}

		private List<IVessel> models;

		public IReadOnlyCollection<IVessel> Models => this.models;

		public void Add(IVessel model)
		{
			this.models.Add(model);
		}

		public IVessel FindByName(string name)
		{
			return this.models.FirstOrDefault(x => x.Name == name);
		}

		public bool Remove(IVessel model)
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
