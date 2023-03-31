using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
	public class BunnyRepository : IRepository<IBunny>
	{
		public BunnyRepository()
		{
			this.models = new List<IBunny>();
		}

		private List<IBunny> models;

		public IReadOnlyCollection<IBunny> Models => this.models;

		public void Add(IBunny model)
		{
			this.models.Add(model);
		}

		public IBunny FindByName(string name)
		{
			return this.models.FirstOrDefault(m => m.Name == name);
		}

		public bool Remove(IBunny model)
		{
			return this.models.Remove(model);
		}
	}
}
