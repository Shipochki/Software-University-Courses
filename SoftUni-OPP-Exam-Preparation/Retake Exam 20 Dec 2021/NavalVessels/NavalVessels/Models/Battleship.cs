using NavalVessels.Models.Contracts;
using System.Text;

namespace NavalVessels.Models
{
	public class Battleship : Vessel, IBattleship
	{
		private const double initalTicknes = 300;
		public Battleship(string name, double mainWeaponCaliber, double speed)
			: base(name, mainWeaponCaliber, speed, initalTicknes)
		{
		}

		private bool sonarMode = false;

		public bool SonarMode => this.sonarMode;


		public void ToggleSonarMode()
		{
			if (this.sonarMode)
			{
				this.sonarMode = false;
				base.mainWeaponCaliber -= 40;
				base.speed += 5;
			}
			else
			{ 
				this.sonarMode = true;
				base.mainWeaponCaliber += 40;
				base.speed -= 5;
			}
		}

		public override string ToString()
		{
			string baseString = base.ToString();
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(baseString);
			if(this.sonarMode)
			{
				sb.AppendLine("*Sonar mode: ON");
			}
			else
			{
				sb.AppendLine("*Sonar mode: OFF");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
