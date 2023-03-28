using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
	public class EquipmentRepository : IRepository<IEquipment>
	{
		public EquipmentRepository()
		{
			this.models = new List<IEquipment>();
		}

		private List<IEquipment> models;

		public IReadOnlyCollection<IEquipment> Models => models;

		public void Add(IEquipment model)
		{
			this.models.Add(model);
		}

		public IEquipment FindByType(string type)
		{
			return this.models.FirstOrDefault(m => m.GetType().Name == type);
		}

		public bool Remove(IEquipment model)
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
