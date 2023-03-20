using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
	public class BoothRepository : IRepository<IBooth>
	{
		public BoothRepository()
		{
			this.models = new List<IBooth>();
		}

		private List<IBooth> models;

		public IReadOnlyCollection<IBooth> Models => this.models;


		public void AddModel(IBooth model)
		{
			this.models.Add(model);
		}
	}
}
