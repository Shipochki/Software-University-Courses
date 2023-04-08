﻿using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
	public class SupplementRepository : IRepository<ISupplement>
	{
		private List<ISupplement> supplements;

		public SupplementRepository()
		{
			this.supplements = new List<ISupplement>();
		}

		public void AddNew(ISupplement model)
		{
			this.supplements.Add(model);
		}

		public ISupplement FindByStandard(int interfaceStandard)
		{
			return this.supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
		}

		public IReadOnlyCollection<ISupplement> Models()
		{
			return this.supplements.AsReadOnly();
		}

		public bool RemoveByName(string typeName)
		{
			ISupplement supplement = this.supplements.FirstOrDefault(s => s.GetType().Name == typeName);
			if (supplement != null)
			{
				this.supplements.Remove(supplement);
				return true;
			}
			return false;
		}
	}
}
