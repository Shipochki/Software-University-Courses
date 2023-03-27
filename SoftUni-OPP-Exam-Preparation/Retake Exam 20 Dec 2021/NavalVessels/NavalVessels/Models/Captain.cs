using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using static NavalVessels.Utilities.Messages.ExceptionMessages;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
	public class Captain : ICaptain
	{
		public Captain(string fullName)
		{
			FullName = fullName;
			this.vessels = new List<IVessel>();
		}

		private string fullName;

		public string FullName
		{
			get { return fullName; }
			private set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException(InvalidCaptainName);
				}
				fullName = value;
			}
		}

		private int combatExperience = 0;

		public int CombatExperience
		{
			get { return combatExperience; }
			private set { combatExperience = value; }
		}

		private ICollection<IVessel> vessels;

		public ICollection<IVessel> Vessels => vessels;


		public void AddVessel(IVessel vessel)
		{
			if (vessel == null)
			{
				throw new NullReferenceException(InvalidVesselForCaptain);
			}

			this.vessels.Add(vessel);
		}

		public void IncreaseCombatExperience()
		{
			this.combatExperience += 10;
		}

		public string Report()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{this.fullName} has {this.combatExperience} combat experience and commands {this.vessels.Count} vessels.");

			if (this.vessels.Count > 0)
			{
				foreach (var vessel in this.vessels)
				{
					sb.AppendLine(vessel.ToString());
				}
			}

			return sb.ToString().TrimEnd();
		}
	}
}
