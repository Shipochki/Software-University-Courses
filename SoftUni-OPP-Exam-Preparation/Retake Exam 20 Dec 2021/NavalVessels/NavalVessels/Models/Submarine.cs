using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
	{
		private const double initalArmour = 200;
		public Submarine(string name, double mainWeaponCaliber, double speed) 
			: base(name, mainWeaponCaliber, speed, initalArmour)
		{
		}

		private bool submergeMode = false;

		public bool SubmergeMode
		{
			get { return submergeMode; }
			private set { submergeMode = value; }
		}


		public void ToggleSubmergeMode()
		{
			if (this.submergeMode)
			{
				this.submergeMode = false;
				base.mainWeaponCaliber -= 40;
				base.speed += 4;
			}
			else
			{
				this.submergeMode = true;
				base.mainWeaponCaliber += 40;
				base.speed -= 4;
			}
		}

		public override string ToString()
		{
			string baseString = base.ToString();
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(baseString);
			if (this.submergeMode)
			{
				sb.AppendLine(" *Submerge mode: ON");
			}
			else
			{
				sb.AppendLine(" *Submerge mode: OFF");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
