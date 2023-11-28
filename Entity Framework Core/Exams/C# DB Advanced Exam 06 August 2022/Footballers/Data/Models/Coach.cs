namespace Footballers.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static DataConfig;

	public class Coach
	{
        public Coach()
        {
            Footballers = new HashSet<Footballer>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxLengthCoachName)]
		public string Name { get; set; } = null!;

		[Required]
		public string Nationality { get; set; } = null!;

		public ICollection<Footballer> Footballers  { get; set;}
	}
}
