using NavalVessels.Core.Contracts;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using static NavalVessels.Utilities.Messages.OutputMessages;
using System.Text;
using System.Threading.Tasks;
using NavalVessels.Models;

namespace NavalVessels.Core
{
	public class Controller : IController
	{
		private IRepository<IVessel> vessels;
		private ICollection<ICaptain> captains;

		public Controller()
		{
			this.vessels = new VesselRepository();
			this.captains = new List<ICaptain>();
		}

		public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
		{
			ICaptain captain = this.captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
			if (captain == null)
			{
				return string.Format(CaptainNotFound, selectedCaptainName);
			}

			IVessel vessel = this.vessels.FindByName(selectedVesselName);
			if (vessel == null)
			{
				return string.Format(VesselNotFound, selectedVesselName);
			}

			if (vessel.Captain != null)
			{
				return string.Format(VesselOccupied, selectedVesselName);
			}

			vessel.Captain = captain;
			captain.Vessels.Add(vessel);

			return string.Format(SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
		}

		public string AttackVessels(string attackingVesselName, string defendingVesselName)
		{
			IVessel attacking = this.vessels.FindByName(attackingVesselName);
			IVessel defending = this.vessels.FindByName(defendingVesselName);


			if (defending == null)
			{
				return string.Format(VesselNotFound, defendingVesselName);
			}
			else if (attacking == null)
			{
				return string.Format(VesselNotFound, attackingVesselName);
			}

			if(defending.ArmorThickness == 0)
			{
				return string.Format(AttackVesselArmorThicknessZero, defendingVesselName);
			}
			else if(attacking.ArmorThickness == 0)
			{
				return string.Format(AttackVesselArmorThicknessZero, attackingVesselName);
			}

			attacking.Attack(defending);
			attacking.Captain.IncreaseCombatExperience();
			defending.Captain.IncreaseCombatExperience();

			return string.Format(SuccessfullyAttackVessel, 
				defendingVesselName, attackingVesselName, defending.ArmorThickness);
		}

		public string CaptainReport(string captainFullName)
		{
			ICaptain captain = this.captains.FirstOrDefault(c => c.FullName == captainFullName);

			return captain.Report();
		}

		public string HireCaptain(string fullName)
		{
			if (this.captains.Any(c => c.FullName == fullName))
			{
				return string.Format(CaptainIsAlreadyHired, fullName);
			}

			ICaptain captain = new Captain(fullName);
			this.captains.Add(captain);
			return string.Format(SuccessfullyAddedCaptain, fullName);
		}

		public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
		{
			if (this.vessels.FindByName(name) != null)
			{
				return string.Format(VesselIsAlreadyManufactured, vesselType, name);
			}

			IVessel vessel = null;
			if (vesselType == nameof(Battleship))
			{
				vessel = new Battleship(name, mainWeaponCaliber, speed);
			}
			else if (vesselType == nameof(Submarine))
			{
				vessel = new Submarine(name, mainWeaponCaliber, speed);
			}
			else
			{
				return string.Format(InvalidVesselType);
			}

			this.vessels.Add(vessel);
			return string.Format(SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
		}

		public string ServiceVessel(string vesselName)
		{
			IVessel vessel = this.vessels.FindByName(vesselName);
			if (vessel == null)
			{
				return string.Format(VesselNotFound, vesselName);
			}

			vessel.RepairVessel();
			return string.Format(SuccessfullyRepairVessel, vesselName);
		}

		public string ToggleSpecialMode(string vesselName)
		{
			IVessel vessel = this.vessels.FindByName(vesselName);
			if (vessel.GetType().Name == nameof(Battleship))
			{
				Battleship battleship = (Battleship)vessel;
				battleship.ToggleSonarMode();
				return string.Format(ToggleBattleshipSonarMode, vesselName);
			}
			else if (vessel.GetType().Name == nameof(Submarine))
			{
				Submarine submarine = (Submarine)vessel;
				submarine.ToggleSubmergeMode();
				return string.Format(ToggleSubmarineSubmergeMode, vesselName);
			}
			else
			{
				return string.Format(VesselNotFound, vesselName);
			}
		}

		public string VesselReport(string vesselName)
		{
			IVessel vessel = this.vessels.FindByName(vesselName);

			return vessel.ToString();
		}
	}
}
