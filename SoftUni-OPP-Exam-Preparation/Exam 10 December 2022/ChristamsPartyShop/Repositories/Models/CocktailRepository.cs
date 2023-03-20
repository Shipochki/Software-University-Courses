using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
	public class CocktailRepository : IRepository<ICocktail>
	{
		public CocktailRepository()
		{
			this.models = new List<ICocktail>();
		}

		private List<ICocktail> models;

		public IReadOnlyCollection<ICocktail> Models => this.models;


		public void AddModel(ICocktail model)
		{
			this.models.Add(model);
		}
	}
}
