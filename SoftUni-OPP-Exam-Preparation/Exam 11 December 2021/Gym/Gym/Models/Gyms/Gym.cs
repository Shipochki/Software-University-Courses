using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using static Gym.Utilities.Messages.ExceptionMessages;
using System.Text;
using System.Linq;
using Gym.Models.Athletes;

namespace Gym.Models.Gyms
{
	public class Gym : IGym
	{
		public Gym(string name, int capacity)
		{
			Name = name;
			this.capacity = capacity;
			this.equipment = new List<IEquipment>();
			this.athletes = new List<IAthlete>();
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set 
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(InvalidGymName);
				}
				name = value; 
			}
		}

		private int capacity;

		public int Capacity => capacity;

		public double EquipmentWeight
		{
			get { return this.equipment.Sum(e => e.Weight); }
		}

		private ICollection<IEquipment> equipment;

		public ICollection<IEquipment> Equipment => this.equipment;


		private ICollection<IAthlete> athletes;

		public ICollection<IAthlete> Athletes => this.athletes;	


		public void AddAthlete(IAthlete athlete)
		{
			if(this.athletes.Count >= this.capacity)
			{
				throw new InvalidOperationException(NotEnoughSize);
			}

			this.athletes.Add(athlete);
		}

		public void AddEquipment(IEquipment equipment)
		{
			this.equipment.Add(equipment);
		}

		public void Exercise()
		{
			foreach (var athlete in this.athletes)
			{
				if(this.GetType().Name == nameof(BoxingGym))
				{
					if(this.athletes.GetType().Name == nameof(Boxer))
					{
						athlete.Exercise();
					}
				}
				else
				{
					if (this.athletes.GetType().Name == nameof(Weightlifter))
					{
						athlete.Exercise();
					}
				}
			}
		}

		public string GymInfo()
		{
			StringBuilder sb= new StringBuilder();

			sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
			if(this.athletes.Count > 0)
			{
				sb.AppendLine($"Athletes: {string.Join(", ", this.athletes.Select(a => a.FullName))}");
			}
			else
			{
				sb.AppendLine("Athletes: No athletes");
			}

			sb.AppendLine($"Equipment total count: {this.equipment.Count}");
			sb.AppendLine($"Equipment total weight: {this.EquipmentWeight} grams");

			return sb.ToString().TrimEnd();
		}

		public bool RemoveAthlete(IAthlete athlete)
		{
			if (this.athletes.Contains(athlete))
			{
				this.athletes.Remove(athlete);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
