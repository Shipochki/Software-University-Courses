namespace Footballers.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static DataConfig;

	public class Team
	{
        public Team()
        {
            TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxLengthTeamName)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(MaxLengthTeamNationality)]
		public string Nationality { get; set; } = null!;

		[Required]
		public int Trophies { get; set; }

		public ICollection<TeamFootballer> TeamsFootballers { get; set; }
	}
}
