using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
	public class RobotRepository : IRepository<IRobot>
	{
		private List<IRobot> robots;

		public RobotRepository()
		{
			this.robots = new List<IRobot>();
		}

		public void AddNew(IRobot model)
		{
			this.robots.Add(model);
		}

		public IRobot FindByStandard(int interfaceStandard)
		{
			IRobot robot = this.robots.FirstOrDefault(r => r.InterfaceStandards.Contains(interfaceStandard));
			return robot;
		}

		public IReadOnlyCollection<IRobot> Models()
		{
			return this.robots.AsReadOnly();
		}

		public bool RemoveByName(string typeName)
		{
			IRobot supplement = this.robots.FirstOrDefault(s => s.Model == typeName);
			if (supplement != null)
			{
				this.robots.Remove(supplement);
				return true;
			}
			return false;
		}
	}
}
