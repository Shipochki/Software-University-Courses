using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using static Formula1.Utilities.ExceptionMessages;

namespace Formula1.Models
{
	public class Race : IRace
	{
		public Race(string raceName, int numberOfLaps)
		{
			RaceName = raceName;
			NumberOfLaps = numberOfLaps;
			this.pilots = new List<IPilot>();
		}

		private string raceName;

		public string RaceName
		{
			get { return raceName; }
			private set
			{
				if (string.IsNullOrEmpty(value) || value.Length < 5)
				{
					throw new ArgumentException(string.Format(InvalidRaceName, value));
				}
				raceName = value;
			}
		}

		private int numberOfLaps;

		public int NumberOfLaps
		{
			get { return numberOfLaps; }
			private set
			{
				if (value < 1)
				{
					throw new ArgumentException(string.Format(InvalidLapNumbers, value));
				}
				numberOfLaps = value;
			}
		}

		public bool TookPlace { get; set; } = false;


		private List<IPilot> pilots;

		public ICollection<IPilot> Pilots => pilots;


		public void AddPilot(IPilot pilot)
		{
			this.pilots.Add(pilot);
		}

		public string RaceInfo()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"The {this.RaceName} race has:");
			sb.AppendLine($"Participants: {this.Pilots.Count}");
			sb.AppendLine($"Number of laps: {this.NumberOfLaps}");
			if (TookPlace)
			{
				sb.AppendLine("Took place: Yes");
			}
			else
			{
				sb.AppendLine("Took place: No");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
