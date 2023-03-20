using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Delicacies.Contracts;

namespace ChristmasPastryShop.Repositories
{
	public class DelicacyRepository : IRepository<IDelicacy>
	{
		public DelicacyRepository()
		{
			this.models = new List<IDelicacy>();
		}

		private List<IDelicacy> models;

		public IReadOnlyCollection<IDelicacy> Models => this.models;


		public void AddModel(IDelicacy model)
		{
			this.models.Add(model);
		}
	}
}
