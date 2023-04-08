using RobotService.Core.Contracts;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using System;
using static RobotService.Utilities.Messages.OutputMessages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models;
using System.Reflection;

namespace RobotService.Core
{
	public class Controller : IController
	{
		private IRepository<ISupplement> suppliments;
		private IRepository<IRobot> robots;

		public Controller()
		{
			this.suppliments = new SupplementRepository();
			this.robots = new RobotRepository();
		}

		public string CreateRobot(string model, string typeName)
		{
			IRobot robot;
			if (typeName == nameof(DomesticAssistant))
			{
				robot = new DomesticAssistant(model);
			}
			else if (typeName == nameof(IndustrialAssistant))
			{
				robot = new IndustrialAssistant(model);
			}
			else
			{
				return string.Format(RobotCannotBeCreated, typeName);
			}

			this.robots.AddNew(robot);

			return string.Format(RobotCreatedSuccessfully, typeName, model);
		}

		public string CreateSupplement(string typeName)
		{
			ISupplement supplement;
			if (typeName == nameof(SpecializedArm))
			{
				supplement = new SpecializedArm();
			}
			else if (typeName == nameof(LaserRadar))
			{
				supplement = new LaserRadar();
			}
			else
			{
				return string.Format(SupplementCannotBeCreated, typeName);
			}

			this.suppliments.AddNew(supplement);

			return string.Format(SupplementCreatedSuccessfully, typeName);
		}

		public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
		{
			ICollection<IRobot> robots = this.robots.Models()
				.Where(r => r.InterfaceStandards.Contains(intefaceStandard))
				.OrderByDescending(r => r.BatteryLevel)
				.ToList();

			if(robots.Count == 0)
			{
				return string.Format(UnableToPerform, intefaceStandard);
			}

			int sum = robots.Sum(r => r.BatteryLevel);

			if(sum < totalPowerNeeded)
			{
				return string.Format(MorePowerNeeded, serviceName, totalPowerNeeded - sum);
			}

			int counter = 0;
			while (totalPowerNeeded != 0)
			{
				foreach (var robot in robots)
				{
					if(robot.BatteryLevel >= totalPowerNeeded)
					{
						robot.ExecuteService(totalPowerNeeded);
						counter++;
						return string.Format(PerformedSuccessfully, serviceName, counter);
					}
					else
					{
						totalPowerNeeded -= robot.BatteryLevel;
						robot.ExecuteService(robot.BatteryLevel);
						counter++;
					}

					if(totalPowerNeeded <= 0) 
					{
						break;
					}
				}
			}

			return string.Format(PerformedSuccessfully,serviceName, counter);
		}

		public string Report()
		{
			ICollection<IRobot> robots = this.robots.Models()
				.OrderByDescending(r => r.BatteryLevel)
				.ThenBy(r => r.BatteryCapacity)
				.ToList();

			StringBuilder sb = new StringBuilder();

			foreach (var robot in robots)
			{
				sb.AppendLine(robot.ToString());
			}

			return sb.ToString().TrimEnd();
		}

		public string RobotRecovery(string model, int minutes)
		{
			ICollection<IRobot> robots = this.robots.Models()
				.Where(r => r.Model == model && r.BatteryLevel < r.BatteryCapacity / 2)
				.ToList();

			foreach (var robot in robots)
			{
				robot.Eating(minutes);
			}

			return string.Format(RobotsFed, robots.Count);
		}

		public string UpgradeRobot(string model, string supplementTypeName)
		{
			ISupplement supplement = this.suppliments
				.Models()
				.FirstOrDefault(s => s.GetType().Name == supplementTypeName);

			ICollection<IRobot> robots = this.robots.Models()
				.Where(r => !r.InterfaceStandards.Contains(supplement.InterfaceStandard) && r.Model == model)
				.ToList();

			if(robots.Count == 0)
			{
				return string.Format(AllModelsUpgraded, model);
			}

			IRobot robot = robots.First();
			robot.InstallSupplement(supplement);

			this.suppliments.RemoveByName(supplementTypeName);

			return string.Format(UpgradeSuccessful, model, supplementTypeName);
		}
	}
}
