using System;
using System.Collections.Generic;
using static RobotService.Utilities.Messages.ExceptionMessages;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;

namespace RobotService.Models
{
	public abstract class Robot : IRobot
	{
		public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
		{
			Model = model;
			BatteryCapacity = batteryCapacity;
			BatteryLevel = batteryCapacity;
			ConvertionCapacityIndex = conversionCapacityIndex;
			this.interfaceStandards = new List<int>();
		}

		private string model;

		public string Model
		{
			get { return model; }
			private set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(ModelNullOrWhitespace);
				}
				model = value;
			}
		}

		private int batteryCapacity;

		public int BatteryCapacity
		{
			get { return batteryCapacity; }
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException(BatteryCapacityBelowZero);
				}
				batteryCapacity = value;
			}
		}

		private int batteryLevel;

		public int BatteryLevel
		{
			get { return batteryLevel; }
			private set { batteryLevel = value; }
		}

		private int convertionCapacityIndex;

		public int ConvertionCapacityIndex
		{
			get { return convertionCapacityIndex; }
			private set { convertionCapacityIndex = value; }
		}

		private List<int> interfaceStandards;

		public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards.AsReadOnly();



		public void Eating(int minutes)
		{
			this.batteryLevel += minutes * this.convertionCapacityIndex;
			if (this.batteryLevel >= batteryCapacity)
			{
				this.batteryLevel = this.batteryCapacity;
			}
		}

		public bool ExecuteService(int consumedEnergy)
		{
			if (this.batteryLevel >= consumedEnergy)
			{
				this.batteryLevel -= consumedEnergy;
				return true;
			}

			return false;
		}

		public void InstallSupplement(ISupplement supplement)
		{
			this.batteryCapacity -= supplement.BatteryUsage;
			this.batteryLevel -= supplement.BatteryUsage;
			this.interfaceStandards.Add(supplement.InterfaceStandard);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{this.GetType().Name} {this.Model}:");
			sb.AppendLine($"--Maximum battery capacity: {this.BatteryCapacity}");
			sb.AppendLine($"--Current battery level: {this.BatteryLevel}");
			if (this.InterfaceStandards.Count == 0)
			{
				sb.AppendLine("--Supplements installed: none");
			}
			else
			{
				sb.AppendLine($"--Supplements installed: {string.Join(" ", this.interfaceStandards)}");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
