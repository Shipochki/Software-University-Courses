using Gym.Core.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using static Gym.Utilities.Messages.ExceptionMessages;
using static Gym.Utilities.Messages.OutputMessages;
using System.Text;
using System.Linq;
using Gym.Models.Gyms;
using Gym.Models.Equipment;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Athletes;

namespace Gym.Core
{
	public class Controller : IController
	{
		private IRepository<IEquipment> equipment;
		private ICollection<IGym> gyms;

		public Controller()
		{
			this.equipment = new EquipmentRepository();
			this.gyms = new List<IGym>();
		}

		public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
		{
			IAthlete athlete = null;
			IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
			bool isAppropriate = false;

			if (athleteType == nameof(Boxer))
			{
				if (gym.GetType().Name == nameof(BoxingGym))
				{
					isAppropriate = true;
					athlete = new Boxer(athleteName, motivation, numberOfMedals);
				}
			}
			else if (athleteType == nameof(Weightlifter))
			{
				if (gym.GetType().Name == nameof(WeightliftingGym))
				{
					isAppropriate = true;
					athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
				}
			}
			else
			{
				throw new InvalidOperationException(InvalidAthleteType);
			}

			if (!isAppropriate)
			{
				return string.Format(InappropriateGym);
			}

			gym.AddAthlete(athlete);
			return string.Format(EntityAddedToGym, athleteType, gymName);
		}

		public string AddEquipment(string equipmentType)
		{
			IEquipment equipment = null;
			if (equipmentType == nameof(BoxingGloves))
			{
				equipment = new BoxingGloves();
			}
			else if (equipmentType == nameof(Kettlebell))
			{
				equipment = new Kettlebell();
			}
			else
			{
				throw new InvalidOperationException(InvalidEquipmentType);
			}

			this.equipment.Add(equipment);
			return string.Format(SuccessfullyAdded, equipmentType);
		}

		public string AddGym(string gymType, string gymName)
		{
			IGym gym = null;
			if (gymType == nameof(BoxingGym))
			{
				gym = new BoxingGym(gymName);
			}
			else if (gymType == nameof(WeightliftingGym))
			{
				gym = new WeightliftingGym(gymName);
			}
			else
			{
				throw new InvalidOperationException(InvalidGymType);
			}

			this.gyms.Add(gym);
			return string.Format(SuccessfullyAdded, gymType);
		}

		public string EquipmentWeight(string gymName)
		{
			IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

			double weight = gym.EquipmentWeight;

			return string.Format(EquipmentTotalWeight, gymName, weight);
		}

		public string InsertEquipment(string gymName, string equipmentType)
		{
			IEquipment equipment = this.equipment.FindByType(equipmentType);

			if (!this.equipment.Remove(equipment))
			{
				throw new InvalidOperationException(string.Format(InexistentEquipment, equipmentType));
			}

			IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
			gym.AddEquipment(equipment);
			return string.Format(EntityAddedToGym, equipmentType, gymName);
		}

		public string Report()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var gym in this.gyms)
			{
				sb.AppendLine(gym.GymInfo());
				sb.AppendLine();
			}

			return sb.ToString().TrimEnd();
		}

		public string TrainAthletes(string gymName)
		{
			IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

			gym.Exercise();

			return string.Format(AthleteExercise, gym.Athletes.Count);
		}
	}
}
