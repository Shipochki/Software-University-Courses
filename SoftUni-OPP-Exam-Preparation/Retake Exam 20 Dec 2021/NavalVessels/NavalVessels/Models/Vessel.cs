using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using static NavalVessels.Utilities.Messages.ExceptionMessages;

namespace NavalVessels.Models
{
    public class Vessel : IVessel
	{
		public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
		{
			Name = name;
			MainWeaponCaliber = mainWeaponCaliber;
			Speed = speed;
			ArmorThickness = armorThickness;
			this.targets = new List<string>();
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException(InvalidVesselName);
				}
				name = value;
			}
		}

		private ICaptain captain;

		public ICaptain Captain
		{
			get { return captain; }
			set
			{
				if (value == null)
				{
					throw new NullReferenceException(InvalidCaptainToVessel);
				}
				captain = value;
			}
		}


		public double ArmorThickness { get; set; }

		protected double mainWeaponCaliber;

		public double MainWeaponCaliber
		{
			get { return mainWeaponCaliber; }
			private set { mainWeaponCaliber = value; }
		}

		protected double speed;

		public double Speed
		{
			get { return speed; }
			private set { speed = value; }
		}

		private ICollection<string> targets;

		public ICollection<string> Targets => targets;

		public void Attack(IVessel target)
		{
			if (target == null)
			{
				throw new NullReferenceException(InvalidTarget);
			}

			if (target.ArmorThickness - this.mainWeaponCaliber <= 0)
			{
				target.ArmorThickness = 0;
				this.targets.Add(target.Name);
			}
			else
			{
				target.ArmorThickness -= this.mainWeaponCaliber;
			}
		}

		public void RepairVessel()
		{
			if(this.GetType().Name == nameof(Battleship))
			{
				if(this.ArmorThickness < 300)
				{
					this.ArmorThickness = 300;
				}
			}
			else if(this.GetType().Name == nameof(Submarine))
			{
				if(this.ArmorThickness < 200)
				{
					this.ArmorThickness = 200;
				}
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"- {this.name}");
			sb.AppendLine($"*Type: {this.GetType().Name}");
			sb.AppendLine($"*Armor thickness: {this.ArmorThickness}");
			sb.AppendLine($"*Main weapon caliber: {this.mainWeaponCaliber}");
			sb.AppendLine($"*Speed: {this.speed} knots");
			if (this.targets.Count == 0)
			{
				sb.AppendLine("*Targets: None");
			}
			else
			{
				sb.AppendLine($"*Targets: {string.Join(", ", this.targets)}");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
